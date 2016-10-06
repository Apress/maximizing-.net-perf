// RuntimeLoader.cpp : Defines the entry point for the console application.
//
#include "stdafx.h"
#include "RuntimeLoader.h"
#ifdef _DEBUG
#define new DEBUG_NEW
#endif


//guid definition missing from corguids.lib - define it ourselves
//static const GUID IID_IGCHostControl = { 0x5513D564, 0x8374, 0x4cb9, 0xAED9, {0x00, 0x83, 0xF41, 0x60A, 0x1D}};
#include "INITGUID.H"
DEFINE_GUID(IID_IGCHostControl, 0x5513D564, 0x8374, 0x4cb9, 0xAE, 0xD9, 0x00, 0x83, 0xF4, 0x16, 0x0A, 0x1D);

#include <mscoree.h>
#import <mscorlib.tlb> rename("ReportEvent","ReportEventCOR")
using namespace mscorlib;
#import "MemLimit\Debug\MemLimit.dll"


// The one and only application object

CWinApp theApp;

using namespace std;

int _tmain(int argc, TCHAR* argv[], TCHAR* envp[])
{
	int nRetCode = 0;

	// initialize MFC and print and error on failure
	if (!AfxWinInit(::GetModuleHandle(NULL), NULL, ::GetCommandLine(), 0)){
		OutputDebugString(_T("Fatal Error: MFC initialization failed\n"));
		nRetCode = 1;
	}
	else
	{
		try{
			if (argc <= 1){
				_tprintf(_T("Specify the name of the program to run with no file extension."));
				return 1;
			}

			TCHAR* fullPath = argv[1];
			_bstr_t runtimeVer("v1.1.4322");
			if (argc >= 3){
				runtimeVer = _bstr_t(argv[2]);
			}

			CComPtr<ICorRuntimeHost> pHost = NULL;
			HRESULT hr = CorBindToRuntimeEx((wchar_t*)runtimeVer, L"svr",
				STARTUP_LOADER_OPTIMIZATION_SINGLE_DOMAIN, CLSID_CorRuntimeHost, IID_ICorRuntimeHost, (void **)&pHost);
			if (!SUCCEEDED(hr)){
				OutputDebugString(_T("CorBindToRuntime failed\n"));
				return 1;
			}

			if (argc >= 4){
				::CoInitialize(NULL);
				int memLimit = _ttoi(argv[3]);
				printf("Memory limit:\t %i bytes\n", memLimit);
				CComPtr<ICorConfiguration> pConfig;
				pHost->GetConfiguration(&pConfig);
				MemLimitLib::IMemControlPtr pMemControl;
				pMemControl.CreateInstance(__uuidof(MemLimitLib::MemControl));
				pMemControl->MaxMem = memLimit;
				CComQIPtr<IGCHostControl> pGCHost(pMemControl);
				pConfig->SetGCHostControl(pGCHost);
			}

			pHost->Start();

			CComPtr<IUnknown>   pAppDomainPunk = NULL;
			hr = pHost->GetDefaultDomain(&pAppDomainPunk);
			CComQIPtr<_AppDomain> pDefaultDomain(pAppDomainPunk);
			CComPtr<_Assembly> pAssem = pDefaultDomain->Load_2(_bstr_t(fullPath));
			CComPtr<_MethodInfo> pEntryPoint = pAssem->EntryPoint;

			printf("Assembly %s launched \n", fullPath);

			_variant_t nullParam(vtMissing);
			pEntryPoint->Invoke_3(vtMissing, NULL);
		}
		catch(_com_error er){
			_bstr_t desc = er.Description();
			TCHAR* errDesc = (TCHAR*)desc;
			_tprintf(errDesc);
			OutputDebugString(errDesc);
		}
	}

	return nRetCode;
}
