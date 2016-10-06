// InteropComTest.cpp : Implementation of DLL Exports.

#include "stdafx.h"
#include "resource.h"

// The module attribute causes DllMain, DllRegisterServer and DllUnregisterServer to be automatically implemented for you
[ module(dll, uuid = "{EE72133F-CF7F-4627-8D26-9C6BD9145730}", 
		 name = "InteropComTest", 
		 helpstring = "InteropComTest 1.0 Type Library",
		 resource_name = "IDR_INTEROPCOMTEST") ];
