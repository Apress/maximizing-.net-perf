

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 6.00.0361 */
/* at Tue Apr 22 20:46:53 2003
 */
/* Compiler settings for _InteropSafeArray.idl:
    Oicf, W1, Zp8, env=Win32 (32b run)
    protocol : dce , ms_ext, c_ext, robust
    error checks: allocation ref bounds_check enum stub_data 
    VC __declspec() decoration level: 
         __declspec(uuid()), __declspec(selectany), __declspec(novtable)
         DECLSPEC_UUID(), MIDL_INTERFACE()
*/
//@@MIDL_FILE_HEADING(  )

#pragma warning( disable: 4049 )  /* more than 64k source lines */


/* verify that the <rpcndr.h> version is high enough to compile this file*/
#ifndef __REQUIRED_RPCNDR_H_VERSION__
#define __REQUIRED_RPCNDR_H_VERSION__ 475
#endif

#include "rpc.h"
#include "rpcndr.h"

#ifndef __RPCNDR_H_VERSION__
#error this stub requires an updated version of <rpcndr.h>
#endif // __RPCNDR_H_VERSION__

#ifndef COM_NO_WINDOWS_H
#include "windows.h"
#include "ole2.h"
#endif /*COM_NO_WINDOWS_H*/

#ifndef ___InteropSafeArray_h__
#define ___InteropSafeArray_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

/* Forward Declarations */ 

#ifndef __IArrayDataTransport_FWD_DEFINED__
#define __IArrayDataTransport_FWD_DEFINED__
typedef interface IArrayDataTransport IArrayDataTransport;
#endif 	/* __IArrayDataTransport_FWD_DEFINED__ */


#ifndef __CArrayDataTransport_FWD_DEFINED__
#define __CArrayDataTransport_FWD_DEFINED__

#ifdef __cplusplus
typedef class CArrayDataTransport CArrayDataTransport;
#else
typedef struct CArrayDataTransport CArrayDataTransport;
#endif /* __cplusplus */

#endif 	/* __CArrayDataTransport_FWD_DEFINED__ */


/* header files for imported files */
#include "prsht.h"
#include "mshtml.h"
#include "mshtmhst.h"
#include "exdisp.h"
#include "objsafe.h"

#ifdef __cplusplus
extern "C"{
#endif 

void * __RPC_USER MIDL_user_allocate(size_t);
void __RPC_USER MIDL_user_free( void * ); 

#ifndef __IArrayDataTransport_INTERFACE_DEFINED__
#define __IArrayDataTransport_INTERFACE_DEFINED__

/* interface IArrayDataTransport */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_IArrayDataTransport;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("6AFC408E-42F4-4947-AD65-56578E30DFE8")
    IArrayDataTransport : public IDispatch
    {
    public:
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE SafeArray( 
            /* [retval][out] */ VARIANT *pRet) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE CStyle( 
            /* [out] */ LONG *pSize,
            /* [retval][out] */ LONG **pRet) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE NoArray( 
            /* [retval][out] */ VARIANT_BOOL *pRet) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IArrayDataTransportVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IArrayDataTransport * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IArrayDataTransport * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IArrayDataTransport * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IArrayDataTransport * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IArrayDataTransport * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IArrayDataTransport * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IArrayDataTransport * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *SafeArray )( 
            IArrayDataTransport * This,
            /* [retval][out] */ VARIANT *pRet);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *CStyle )( 
            IArrayDataTransport * This,
            /* [out] */ LONG *pSize,
            /* [retval][out] */ LONG **pRet);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *NoArray )( 
            IArrayDataTransport * This,
            /* [retval][out] */ VARIANT_BOOL *pRet);
        
        END_INTERFACE
    } IArrayDataTransportVtbl;

    interface IArrayDataTransport
    {
        CONST_VTBL struct IArrayDataTransportVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IArrayDataTransport_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IArrayDataTransport_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IArrayDataTransport_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IArrayDataTransport_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IArrayDataTransport_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IArrayDataTransport_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IArrayDataTransport_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IArrayDataTransport_SafeArray(This,pRet)	\
    (This)->lpVtbl -> SafeArray(This,pRet)

#define IArrayDataTransport_CStyle(This,pSize,pRet)	\
    (This)->lpVtbl -> CStyle(This,pSize,pRet)

#define IArrayDataTransport_NoArray(This,pRet)	\
    (This)->lpVtbl -> NoArray(This,pRet)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [helpstring][id] */ HRESULT STDMETHODCALLTYPE IArrayDataTransport_SafeArray_Proxy( 
    IArrayDataTransport * This,
    /* [retval][out] */ VARIANT *pRet);


void __RPC_STUB IArrayDataTransport_SafeArray_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring][id] */ HRESULT STDMETHODCALLTYPE IArrayDataTransport_CStyle_Proxy( 
    IArrayDataTransport * This,
    /* [out] */ LONG *pSize,
    /* [retval][out] */ LONG **pRet);


void __RPC_STUB IArrayDataTransport_CStyle_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring][id] */ HRESULT STDMETHODCALLTYPE IArrayDataTransport_NoArray_Proxy( 
    IArrayDataTransport * This,
    /* [retval][out] */ VARIANT_BOOL *pRet);


void __RPC_STUB IArrayDataTransport_NoArray_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IArrayDataTransport_INTERFACE_DEFINED__ */



#ifndef __InteropSafeArray_LIBRARY_DEFINED__
#define __InteropSafeArray_LIBRARY_DEFINED__

/* library InteropSafeArray */
/* [helpstring][uuid][version] */ 


EXTERN_C const IID LIBID_InteropSafeArray;

EXTERN_C const CLSID CLSID_CArrayDataTransport;

#ifdef __cplusplus

class DECLSPEC_UUID("90C7BDB0-9402-42BF-8E94-651430BC9BAC")
CArrayDataTransport;
#endif
#endif /* __InteropSafeArray_LIBRARY_DEFINED__ */

/* Additional Prototypes for ALL interfaces */

unsigned long             __RPC_USER  VARIANT_UserSize(     unsigned long *, unsigned long            , VARIANT * ); 
unsigned char * __RPC_USER  VARIANT_UserMarshal(  unsigned long *, unsigned char *, VARIANT * ); 
unsigned char * __RPC_USER  VARIANT_UserUnmarshal(unsigned long *, unsigned char *, VARIANT * ); 
void                      __RPC_USER  VARIANT_UserFree(     unsigned long *, VARIANT * ); 

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif


