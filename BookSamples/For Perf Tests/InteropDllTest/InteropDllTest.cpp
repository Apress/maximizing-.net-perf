// InteropDllTest.cpp : Defines the entry point for the DLL application.
//

#include "stdafx.h"
#include <stdio.h>

BOOL APIENTRY DllMain( HANDLE hModule, 
                       DWORD  ul_reason_for_call, 
                       LPVOID lpReserved
					 )
{
    return TRUE;
}

int WINAPI ZeroParams() {
	return 22;
}

int WINAPI OneBlittableParam(int i){
	return 22;
	//return i + 1;
}

int WINAPI ConstantStringParam(LPCWSTR str){
	return 22;
	//return (int)wcslen(str);
}

int WINAPI ConstantStringParamAnsi(LPCSTR str){
	return 22;
	//return (int)strlen(str);
}

int WINAPI ChangeableStringParam(LPWSTR str, int length){
	return 22;
	/*
	const wchar_t* src = L"abcdefghijklmnopqrstruvwxyz";
	::wcsncpy(str, src, length - 1);
	str[length-1] = L'\0';
	return (int)wcslen(str)+1;
	*/
}

int WINAPI ConstArray(int* data, int length){
	return 22;
	/*
	int sum = 0;
	for(int i = 0; i < length; ++i){
		sum += data[i];
	}
	return sum;
	*/
}

int WINAPI ConstArrayIncorrectType(void* data, int length){
	return 22;
	//return ConstArray((int*)data, length);
}

int WINAPI ChangeableArray(int* data, int length){
	return 22;
	/*
		int sum = 0;
	for(int i = 0; i < length; ++i){
		sum += data[i];
		++ data[i];
	}
	return sum;
	*/
}

int WINAPI CharacterSetTestW(wchar_t* s){
	return 22;
	//return (int)wcslen(s);
}

int WINAPI CharacterSetTestA(char* s){
	return 22;
	/*
	wchar_t* ws = new wchar_t[strlen(s)+1];
	swprintf(ws, L"%S", s);
	int ret = CharacterSetTestW(ws);
	delete[] ws;
	return ret;
	*/
}

