// Test.cpp : Implementation of CTest

#include "stdafx.h"
#include "Test.h"


// CTest


STDMETHODIMP CTest::Thrower(void)
{
	return E_FAIL;
}

STDMETHODIMP CTest::DoNothing(void)
{
	return S_OK;
}
