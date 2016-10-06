// Test.h : Declaration of the CTest

#pragma once
#include "resource.h"       // main symbols


// ITest
[
	object,
	uuid("3A0282C6-3D37-4BF0-8590-E0AF712FFAC1"),
	dual,	helpstring("ITest Interface"),
	pointer_default(unique)
]
__interface ITest : IDispatch
{
	[id(1), helpstring("method Thrower")] HRESULT Thrower(void);
	[id(2), helpstring("method DoNothing")] HRESULT DoNothing(void);
};



// CTest

[
	coclass,
	threading("both"),
	vi_progid("InteropComTest.Test"),
	progid("InteropComTest.Test.1"),
	version(1.0),
	uuid("261B44AA-1D3B-4041-9E8B-109BC8D0F4CB"),
	helpstring("Test Class")
]
class ATL_NO_VTABLE CTest : 
	public ITest
{
public:
	CTest()
	{
	}


	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct()
	{
		return S_OK;
	}
	
	void FinalRelease() 
	{
	}

public:

	STDMETHOD(Thrower)(void);
	STDMETHOD(DoNothing)(void);
};

