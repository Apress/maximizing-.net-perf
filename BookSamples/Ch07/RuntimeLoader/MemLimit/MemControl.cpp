// MemControl.cpp : Implementation of CMemControl

#include "stdafx.h"
#include "MemControl.h"


// CMemControl


STDMETHODIMP CMemControl::get_MaxMem(LONG* pVal)
{
	*pVal = (LONG)m_memLimit;

	return S_OK;
}

STDMETHODIMP CMemControl::put_MaxMem(LONG newVal)
{
	m_memLimit = (SIZE_T)newVal;

	return S_OK;
}
