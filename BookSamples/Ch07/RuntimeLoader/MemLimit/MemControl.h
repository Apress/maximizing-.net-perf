// MemControl.h : Declaration of the CMemControl

#pragma once
#include "resource.h"       // main symbols
#include "INITGUID.H"
DEFINE_GUID(IID_IGCHostControl, 0x5513D564, 0x8374, 0x4cb9, 0xAE, 0xD9, 0x00, 0x83, 0xF4, 0x16, 0x0A, 0x1D);

#include <mscoree.h>

#include "MemLimit.h"


// CMemControl

class ATL_NO_VTABLE CMemControl : 
	public CComObjectRootEx<CComSingleThreadModel>,
	public CComCoClass<CMemControl, &CLSID_MemControl>,
	public IDispatchImpl<IMemControl, &IID_IMemControl, &LIBID_MemLimitLib, /*wMajor =*/ 1, /*wMinor =*/ 0>,
	public IGCHostControl
{
public:
	CMemControl()
	{
	}

	DECLARE_REGISTRY_RESOURCEID(IDR_MEMCONTROL)


	BEGIN_COM_MAP(CMemControl)
		COM_INTERFACE_ENTRY(IMemControl)
		COM_INTERFACE_ENTRY(IDispatch)
		COM_INTERFACE_ENTRY(IGCHostControl)
	END_COM_MAP()


	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct()
	{
		m_memLimit = 0;
		return S_OK;
	}

	void FinalRelease() 
	{
	}

	virtual HRESULT STDMETHODCALLTYPE RequestVirtualMemLimit(SIZE_T sztMaxVirtualMemMB, SIZE_T *psztNewMaxVirtualMemMB){
		if (sztMaxVirtualMemMB < m_memLimit)
			*psztNewMaxVirtualMemMB = sztMaxVirtualMemMB;
		else{
			m_memLimit = (SIZE_T)(m_memLimit * 1.02);
			*psztNewMaxVirtualMemMB = m_memLimit;
		}
		return S_OK;
	}

public:

	STDMETHOD(get_MaxMem)(LONG* pVal);
	STDMETHOD(put_MaxMem)(LONG newVal);

private:
	SIZE_T m_memLimit;
};

OBJECT_ENTRY_AUTO(__uuidof(MemControl), CMemControl)
