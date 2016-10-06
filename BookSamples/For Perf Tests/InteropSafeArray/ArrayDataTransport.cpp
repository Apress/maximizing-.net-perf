// ArrayDataTransport.cpp : Implementation of CArrayDataTransport

#include "stdafx.h"
#include "ArrayDataTransport.h"
#include "atlsafe.h"


// CArrayDataTransport
static const long s_size = 100;


STDMETHODIMP CArrayDataTransport::SafeArray(VARIANT* pRet)
{
	CComSafeArray<LONG> data((ULONG)s_size);
	for (int ix = 0; ix < s_size; ++ix){
		data.SetAt(ix, ix);
	}
	CComVariant var(data);
	var.Detach(pRet);

	return S_OK;
}

STDMETHODIMP CArrayDataTransport::CStyle(LONG* pSize, LONG** pRet)
{
	*pSize = s_size;
	LONG* pData = (LONG*)CoTaskMemAlloc(s_size*sizeof(LONG));
	for (int ix = 0; ix < s_size; ++ix){
		pData[ix] = ix;
	}
	*pRet = pData;

	return S_OK;
}

STDMETHODIMP CArrayDataTransport::NoArray(VARIANT_BOOL* pRet)
{
	*pRet = VARIANT_TRUE;

	return S_OK;
}
