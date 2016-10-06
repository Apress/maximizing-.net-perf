// ArrayDataTransport.h : Declaration of the CArrayDataTransport

#pragma once
#include "resource.h"       // main symbols


// IArrayDataTransport
[
	object,
	uuid("6AFC408E-42F4-4947-AD65-56578E30DFE8"),
	dual,	helpstring("IArrayDataTransport Interface"),
	pointer_default(unique)
]
__interface IArrayDataTransport : IDispatch
{
	[id(1), helpstring("method SafeArray")] HRESULT SafeArray([out,retval] VARIANT* pRet);
	[id(2), helpstring("method CStyle")] HRESULT CStyle([out] LONG* pSize, [out,retval] LONG** pRet);
	[id(3), helpstring("method NoArray")] HRESULT NoArray([out,retval] VARIANT_BOOL* pRet);
};



// CArrayDataTransport

[
	coclass,
	threading("apartment"),
	vi_progid("InteropSafeArray.ArrayDataTransport"),
	progid("InteropSafeArray.ArrayDataTransport.1"),
	version(1.0),
	uuid("90C7BDB0-9402-42BF-8E94-651430BC9BAC"),
	helpstring("ArrayDataTransport Class")
]
class ATL_NO_VTABLE CArrayDataTransport : 
	public IArrayDataTransport
{
public:
	CArrayDataTransport()
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

	STDMETHOD(SafeArray)(VARIANT* pRet);
	STDMETHOD(CStyle)(LONG* pSize, LONG** pRet);
	STDMETHOD(NoArray)(VARIANT_BOOL* pRet);
};

