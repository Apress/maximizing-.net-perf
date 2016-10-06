
//  Microsoft (R) .NET Framework IL Disassembler.  Version 1.0.3705.0
//  Copyright (C) Microsoft Corporation 1998-2001. All rights reserved.

.assembly extern /*23000001*/ mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 1:0:3300:0
}
.assembly /*20000001*/ ExceptionHandling
{
  .custom /*0C000001:0A000001*/ instance void [mscorlib/* 23000001 */]System.Reflection.AssemblyKeyNameAttribute/* 01000003 */::.ctor(string) /* 0A000001 */ = ( 01 00 00 00 00 ) 
  .custom /*0C000002:0A000002*/ instance void [mscorlib/* 23000001 */]System.Reflection.AssemblyKeyFileAttribute/* 01000004 */::.ctor(string) /* 0A000002 */ = ( 01 00 00 00 00 ) 
  .custom /*0C000003:0A000003*/ instance void [mscorlib/* 23000001 */]System.Reflection.AssemblyDelaySignAttribute/* 01000005 */::.ctor(bool) /* 0A000003 */ = ( 01 00 00 00 00 ) 
  .custom /*0C000004:0A000006*/ instance void [mscorlib/* 23000001 */]System.Reflection.AssemblyTrademarkAttribute/* 01000008 */::.ctor(string) /* 0A000006 */ = ( 01 00 00 00 00 ) 
  .custom /*0C000005:0A000007*/ instance void [mscorlib/* 23000001 */]System.Reflection.AssemblyCopyrightAttribute/* 01000009 */::.ctor(string) /* 0A000007 */ = ( 01 00 00 00 00 ) 
  .custom /*0C000006:0A000008*/ instance void [mscorlib/* 23000001 */]System.Reflection.AssemblyProductAttribute/* 0100000A */::.ctor(string) /* 0A000008 */ = ( 01 00 00 00 00 ) 
  .custom /*0C000007:0A000009*/ instance void [mscorlib/* 23000001 */]System.Reflection.AssemblyCompanyAttribute/* 0100000B */::.ctor(string) /* 0A000009 */ = ( 01 00 00 00 00 ) 
  .custom /*0C000008:0A00000A*/ instance void [mscorlib/* 23000001 */]System.Reflection.AssemblyConfigurationAttribute/* 0100000C */::.ctor(string) /* 0A00000A */ = ( 01 00 00 00 00 ) 
  .custom /*0C000009:0A00000B*/ instance void [mscorlib/* 23000001 */]System.Reflection.AssemblyDescriptionAttribute/* 0100000D */::.ctor(string) /* 0A00000B */ = ( 01 00 00 00 00 ) 
  .custom /*0C00000A:0A00000C*/ instance void [mscorlib/* 23000001 */]System.Reflection.AssemblyTitleAttribute/* 0100000E */::.ctor(string) /* 0A00000C */ = ( 01 00 00 00 00 ) 
  .hash algorithm 0x00008004
  .ver 1:0:796:34077
}
.module ExceptionHandling.dll
// MVID: {1A378D36-5A3D-4B04-86C0-55D168180F6F}
.imagebase 0x11000000
.subsystem 0x00000003
.file alignment 512
.corflags 0x00000001
// Image base: 0x03000000
//
// ============== CLASS STRUCTURE DECLARATION ==================
//
.namespace ExceptionHandling
{
  .class /*02000002*/ public auto ansi beforefieldinit GenerateAndCatchException
         extends [mscorlib/* 23000001 */]System.Object/* 01000001 */
  {
  } // end of class GenerateAndCatchException

} // end of namespace ExceptionHandling


// =============================================================


// =============== GLOBAL FIELDS AND METHODS ===================


// =============================================================


// =============== CLASS MEMBERS DECLARATION ===================
//   note that class flags, 'extends' and 'implements' clauses
//          are provided here for information only

.namespace ExceptionHandling
{
  .class /*02000002*/ public auto ansi beforefieldinit GenerateAndCatchException
         extends [mscorlib/* 23000001 */]System.Object/* 01000001 */
  {
    .method /*06000001*/ private hidebysig 
            instance class [mscorlib/* 23000001 */]System.Array/* 01000002 */ 
            GetArray() cil managed
    // SIG: 20 00 12 09
    {
      // Method begins at RVA 0x2050
      // Code size       2 (0x2)
      .maxstack  1
      IL_0000:  /* 14   |                  */ ldnull
      IL_0001:  /* 2A   |                  */ ret
    } // end of method GenerateAndCatchException::GetArray

    .method /*06000002*/ public hidebysig 
            instance void  FaultHandler() cil managed
    // SIG: 20 00 01
    {
      // Method begins at RVA 0x2060
      // Code size       25 (0x19)
      .maxstack  2
      .locals /*11000001*/ init (class [mscorlib/* 23000001 */]System.Array/* 01000002 */ V_0,
               int32 V_1)
      .try
      {
        IL_0000:  /* 02   |                  */ ldarg.0
        IL_0001:  /* 28   | (06)000001       */ call       instance class [mscorlib/* 23000001 */]System.Array/* 01000002 */ ExceptionHandling.GenerateAndCatchException/* 02000002 */::GetArray() /* 06000001 */
        IL_0006:  /* 0A   |                  */ stloc.0
        IL_0007:  /* 06   |                  */ ldloc.0
        IL_0008:  /* 17   |                  */ ldc.i4.1
        IL_0009:  /* 6F   | (0A)00000D       */ callvirt   instance int32 [mscorlib/* 23000001 */]System.Array/* 01000002 */::GetLength(int32) /* 0A00000D */
        IL_000e:  /* 0B   |                  */ stloc.1
        IL_000f:  /* 07   |                  */ ldloc.1
        IL_0010:  /* 17   |                  */ ldc.i4.1
        IL_0011:  /* 58   |                  */ add
        IL_0012:  /* 0B   |                  */ stloc.1
        IL_0013:  /* DE   | 03               */ leave.s    IL_0018

      }  // end .try
      fault
      {
        IL_0015:  /* 26   |                  */ pop
        IL_0016:  /* DE   | 00               */ leave.s    IL_0018

      }  // end handler
      // HEX: 00 00 00 00 00 00 00 00 15 00 00 00 15 00 00 00 03 00 00 00 0F 00 00 01
      IL_0018:  /* 2A   |                  */ ret
    } // end of method GenerateAndCatchException::FaultHandler

    .method /*06000003*/ public hidebysig 
            instance void  TypeFiltered() cil managed
    // SIG: 20 00 01
    {
      // Method begins at RVA 0x20a4
      // Code size       25 (0x19)
      .maxstack  2
      .locals /*11000001*/ init (class [mscorlib/* 23000001 */]System.Array/* 01000002 */ V_0,
               int32 V_1)
      .try
      {
        IL_0000:  /* 02   |                  */ ldarg.0
        IL_0001:  /* 28   | (06)000001       */ call       instance class [mscorlib/* 23000001 */]System.Array/* 01000002 */ ExceptionHandling.GenerateAndCatchException/* 02000002 */::GetArray() /* 06000001 */
        IL_0006:  /* 0A   |                  */ stloc.0
        IL_0007:  /* 06   |                  */ ldloc.0
        IL_0008:  /* 17   |                  */ ldc.i4.1
        IL_0009:  /* 6F   | (0A)00000D       */ callvirt   instance int32 [mscorlib/* 23000001 */]System.Array/* 01000002 */::GetLength(int32) /* 0A00000D */
        IL_000e:  /* 0B   |                  */ stloc.1
        IL_000f:  /* 07   |                  */ ldloc.1
        IL_0010:  /* 17   |                  */ ldc.i4.1
        IL_0011:  /* 58   |                  */ add
        IL_0012:  /* 0B   |                  */ stloc.1
        IL_0013:  /* DE   | 03               */ leave.s    IL_0018

      }  // end .try
      catch [mscorlib/* 23000001 */]System.Exception/* 0100000F */ 
      {
        IL_0015:  /* 26   |                  */ pop
        IL_0016:  /* DE   | 00               */ leave.s    IL_0018

      }  // end handler
      // HEX: 00 00 00 00 00 00 00 00 15 00 00 00 15 00 00 00 03 00 00 00 0F 00 00 01
      IL_0018:  /* 2A   |                  */ ret
    } // end of method GenerateAndCatchException::TypeFiltered

    .method /*06000004*/ public hidebysig 
            instance void  UserFiltered() cil managed
    // SIG: 20 00 01
    {
      .maxstack  2
      .locals /*11000001*/ init (class [mscorlib/* 23000001 */]System.Array/* 01000002 */ V_0,
               int32 V_1)
//      .try
//      {
        IL_0000:  /* 02   |                  */ ldarg.0
        IL_0001:  /* 28   | (06)000001       */ call       instance class [mscorlib/* 23000001 */]System.Array/* 01000002 */ ExceptionHandling.GenerateAndCatchException/* 02000002 */::GetArray() /* 06000001 */
        IL_0006:  /* 0A   |                  */ stloc.0
        IL_0007:  /* 06   |                  */ ldloc.0
        IL_0008:  /* 17   |                  */ ldc.i4.1
        IL_0009:  /* 6F   | (0A)00000D       */ callvirt   instance int32 [mscorlib/* 23000001 */]System.Array/* 01000002 */::GetLength(int32) /* 0A00000D */
        IL_000e:  /* 0B   |                  */ stloc.1
        IL_000f:  /* 07   |                  */ ldloc.1
        IL_0010:  /* 17   |                  */ ldc.i4.1
        IL_0011:  /* 58   |                  */ add
        IL_0012:  /* 0B   |                  */ stloc.1
        IL_0013:  /* DE   | 03               */ leave.s    IL_0022
//      }  // end .try        
        IL_0015:  ldloc.0
        IL_0016:  ldnull
        IL_0017:  ceq
        IL_0018:  brtrue.s   IL_001d
        IL_001a:  ldc.i4.0
        IL_001b:  br.s       IL_001e
        IL_001d:  ldc.i4.1
        IL_001e:  endfilter
//      {
        IL_001f:  /* 26   |                  */ pop
        IL_0020:  /* DE   | 00               */ leave.s    IL_0022

 //     }  // end handler
	  
        
.try IL_0000 to IL_0015 filter IL_0015 handler IL_001f to IL_0020
      IL_0022:  /* 2A   |                  */ ret
    } // end of method GenerateAndCatchException::UserFiltered

    .method /*06000005*/ public hidebysig specialname rtspecialname 
            instance void  .ctor() cil managed
    // SIG: 20 00 01
    {
      // Method begins at RVA 0x212c
      // Code size       7 (0x7)
      .maxstack  1
      IL_0000:  /* 02   |                  */ ldarg.0
      IL_0001:  /* 28   | (0A)00000E       */ call       instance void [mscorlib/* 23000001 */]System.Object/* 01000001 */::.ctor() /* 0A00000E */
      IL_0006:  /* 2A   |                  */ ret
    } // end of method GenerateAndCatchException::.ctor

  } // end of class GenerateAndCatchException


// =============================================================

} // end of namespace ExceptionHandling

//*********** DISASSEMBLY COMPLETE ***********************
// WARNING: Created Win32 resource file ExceptionHandling.res
