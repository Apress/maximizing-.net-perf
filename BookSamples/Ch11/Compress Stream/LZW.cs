using System;

namespace DotNetPerformance.IO
{
	public class LZW: ICompress{
		static readonly int STACK_SIZE = 4000;
		static readonly byte BITS = 14;
		static readonly short TABLE_SIZE = 18041;
		static readonly byte HASHING_SHIFT = (byte)(BITS - 8);
		static readonly int MAX_VALUE = (1 << BITS) - 1;
		static readonly int MAX_CODE= MAX_VALUE - 1;
		/* The string table size needs to be a */
		/* prime number that is somewhat larger*/
		/* than 2**BITS.                       */

		//Compress class level variable
		//*****************************
		private int[] in_code_value;		  /* This is the code value array        */
		private uint[] in_prefix_code;        /* This array holds the prefix codes   */
		private byte[] in_append_character;  /* This array holds the appended chars */
		private byte[] in_decode_stack= new byte[STACK_SIZE];  /* This array holds the decoded string */

		private int in_string_code = -1;
		int output_bit_count=0;
		ulong output_bit_buffer=0L;
		uint in_next_code = 256;/* Next code is the next available string code*/
		//****************************

		//Expand class level variables
		//****************************
		private int[] out_code_value;		  /* This is the code value array        */
		private uint[] out_prefix_code;        /* This array holds the prefix codes   */
		private byte[] out_append_character;  /* This array holds the appended chars */
		private byte[] out_decode_stack= new byte[STACK_SIZE];  /* This array holds the decoded string */

		int input_bit_count=0;
		uint input_bit_buffer=0;
		uint out_next_code = 256; /* This is the next available code to define */
		uint new_code;
		uint old_code;
		int character;
		bool needExpandInit = true;
		//*****************************

		private void InitCompress(){
			in_code_value = new int[TABLE_SIZE];
			in_prefix_code = new uint[TABLE_SIZE];
			in_append_character = new byte[TABLE_SIZE];

			for (int i=0;i<TABLE_SIZE;i++)  /* Clear out the string table before starting */
				in_code_value[i]=-1;
		}

		private void InitExpand(){
			out_code_value = new int[TABLE_SIZE];
			out_prefix_code = new uint[TABLE_SIZE];
			out_append_character = new byte[TABLE_SIZE];

			for (int i=0;i<TABLE_SIZE;i++)  /* Clear out the string table before starting */
				out_code_value[i]=-1;
		}

		public byte[] Compress(byte[] input){
			if (in_code_value == null)
				InitCompress();

			byte character;
			uint index;

			System.Collections.ArrayList output = new System.Collections.ArrayList();

			int ix = 0;
			if (in_string_code == -1){
				in_string_code = input[0];
				++ix;
			}
			for(; ix < input.Length; ++ix){
				character = input[ix];
				index=(uint)find_match(in_string_code,character);	/* See if the string is in */
				if (in_code_value[index] != -1)					/* the table.  If it is,   */
					in_string_code=in_code_value[index];				/* get the code value.  If */
				else {											/* the string is not in the*/
					/* table, try to add it.   */
					if (in_next_code <= MAX_CODE) {
						in_code_value[index]=(int)in_next_code++;
						in_prefix_code[index]=(uint)in_string_code;
						in_append_character[index]=character;
					}
					output_code(output,(uint)in_string_code);	/* When a string is found  */
					in_string_code=character;				/* that is not in the table*/
				}										/* I output the last string*/
			}											/* after adding the new one*/

			return (byte[])output.ToArray(typeof(byte));
		}

		public byte[] GetCompressRemainder(){
			System.Collections.ArrayList output = new System.Collections.ArrayList();
			output_code(output,(uint)in_string_code);	/* Output the last code               */
			output_code(output,(uint)MAX_VALUE);		/* Output the end of buffer code      */
			output_code(output,0);						/* This code flushes the output buffer*/
			return (byte[])output.ToArray(typeof(byte));
		}

		public byte[] Expand(byte[] input){
			int code;
			if (out_code_value == null){
				InitExpand();
			}

			byte[] stringData;
			int currentInputIndex = 0;

			System.Collections.ArrayList output = new System.Collections.ArrayList();

			if (needExpandInit){
				code =input_code(input, ref currentInputIndex);	/* Read in the first code, initialize the */
				if (code == -1){
					return (byte[])output.ToArray(typeof(byte));
				}
				else
					old_code = (uint)code;

				character=(int)old_code;							/* character variable, and send the first */
				output.Add((byte)old_code);							/* code to the output file                */
			}
			needExpandInit = false;
			while ((code=input_code(input, ref currentInputIndex)) != (MAX_VALUE)) {
				if (code == -1){
					return (byte[])output.ToArray(typeof(byte));
				}
				else
					new_code = (uint)code;

				/*
				** This code checks for the special STRING+CHARACTER+STRING+CHARACTER+STRING
				** case which generates an undefined code.  It handles it by decoding
				** the last code, and adding a single character to the end of the decode string.
				*/
				int buffIndex;
				if (new_code>=out_next_code) {
					out_decode_stack[0]=(byte)character;
					buffIndex = 1;
					stringData=decode_string(out_decode_stack,old_code, ref buffIndex);
				}
					/*
					** Otherwise we do a straight decode of the new code.
					*/
				else{
					buffIndex = 0;
					stringData=decode_string(out_decode_stack,new_code, ref buffIndex);
				}
				/*
				** Now we output the decoded string in reverse order.
				*/
				
				character=stringData[buffIndex];
				while (buffIndex >= 0)
					output.Add(stringData[buffIndex--]);
				/*
				** Finally, if possible, add a new code to the string table.
				*/
				if (out_next_code <= MAX_CODE) {
					out_prefix_code[out_next_code]=old_code;
					out_append_character[out_next_code]=(byte)character;
					out_next_code++;
				}
				old_code=new_code;

			}

			return (byte[])output.ToArray(typeof(byte));
		}

		/*
		** This routine simply decodes a string from the string table, storing
		** it in a buffer.  The buffer can then be output in reverse order by
		** the expansion program.
		*/

		private byte[] decode_string(byte[] buffer, uint code, ref int bufferIndex) {
			int i=bufferIndex;
			while (code > 255) {
				buffer[i] = out_append_character[code];
				code=out_prefix_code[code];
				if (i++>=4094) {
					throw new ArgumentException("File data is corrupt");
				}
			}
			bufferIndex = i;
			buffer[i]=(byte)code;
			return buffer;
		}

		/*
		** This is the hashing routine.  It tries to find a match for the prefix+char
		** string in the string table.  If it finds it, the index is returned.  If
		** the string is not found, the first available index in the string table is
		** returned instead.
		*/
		private int find_match(int hash_prefix,uint hash_character) {
			int index;
			int offset;

			index = (int)((hash_character << HASHING_SHIFT) ^ hash_prefix);
			if (index == 0)
				offset = 1;
			else
				offset = TABLE_SIZE - index;
			while (true) {
				if (in_code_value[index] == -1)
					return(index);
				if (in_prefix_code[index] == hash_prefix && 
					in_append_character[index] == hash_character)
					return(index);
				index -= offset;
				if (index < 0)
					index += TABLE_SIZE;
			}
		}
		
		private void output_code(System.Collections.ArrayList output,uint code) {
			output_bit_buffer |= (ulong) code << (32-BITS-output_bit_count);
			output_bit_count += BITS;
			while (output_bit_count >= 8) {
				output.Add((byte)(output_bit_buffer >> 24));
				output_bit_buffer <<= 8;
				output_bit_count -= 8;
			}
		}

		int input_code(byte[] queue, ref int index){
			int return_value;

			while (input_bit_count <= 24) {
				if (index == queue.Length)
					return -1;

				input_bit_buffer |= 
					(uint) queue[index] << (24-input_bit_count);
				input_bit_count += 8;
				++index;
			}
			return_value= (int)(input_bit_buffer >> (32-BITS));
			input_bit_buffer <<= BITS;
			input_bit_count -= BITS;
			return(return_value);
		}

	}
}
