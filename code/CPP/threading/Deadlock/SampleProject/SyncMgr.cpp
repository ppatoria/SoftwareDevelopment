#include "stdafx.h"

DHSyncManager::DHSyncManager(DHContext *pContext)
{
    m_cRef = 0;
    m_pCLRSyncManager = NULL;
    m_pContext = pContext;
}

DHSyncManager::~DHSyncManager()
{
    m_pCLRSyncManager->Release();
}

// IUnknown functions

STDMETHODIMP_(DWORD) DHSyncManager::AddRef()
{
    return InterlockedIncrement(&m_cRef);
}

STDMETHODIMP_(DWORD) DHSyncManager::Release()
{
	ULONG cRef = InterlockedDecrement(&m_cRef);
	if (cRef == 0)
    {
        delete this;
    }
	return cRef;
}

STDMETHODIMP DHSyncManager::QueryInterface(const IID &riid, void **ppvObject)
{
	if (riid == IID_IUnknown || riid == IID_IHostSyncManager)
	{
		*ppvObject = this;
		AddRef();
		return S_OK;
	}

	*ppvObject = NULL;
	return E_NOINTERFACE;
}

// IHostSyncManager functions

STDMETHODIMP DHSyncManager::SetCLRSyncManager(/* in */ ICLRSyncManager *pManager)
{
	m_pCLRSyncManager = pManager;
	return S_OK;
}

STDMETHODIMP DHSyncManager::CreateCrst(/* out */ IHostCrst **ppCrst)
{
	IHostCrst* pCrst = new DHCrst;
	if (!pCrst)
    {
        _ASSERTE(!"Failed to allocate a new DHCrst");
        *ppCrst = NULL;
		return E_OUTOFMEMORY;
    }

    pCrst->QueryInterface(IID_IHostCrst, (void**)ppCrst);
    return S_OK;
}

STDMETHODIMP DHSyncManager::CreateCrstWithSpinCount(/* in */ DWORD dwSpinCount, /* out */ IHostCrst **ppCrst)
{
    IHostCrst* pCrst = new DHCrst(dwSpinCount);
    if (!pCrst)
    {
        _ASSERTE(!"Failed to allocate a new DHCrstWithSpinCount");
        *ppCrst = NULL;
        return E_OUTOFMEMORY;
    }

    pCrst->QueryInterface(IID_IHostCrst, (void**)ppCrst);
    return S_OK;
}

STDMETHODIMP DHSyncManager::CreateAutoEvent(/* out */IHostAutoEvent **ppEvent)
{
    DHAutoEvent* pEvent = new DHAutoEvent(-1);
    if (!pEvent)
    {
        _ASSERTE(!"Failed to allocate a new AutoEvent");
        *ppEvent = NULL;
        return E_OUTOFMEMORY;
    }

    pEvent->QueryInterface(IID_IHostAutoEvent, (void**)ppEvent);
    return S_OK;
}

STDMETHODIMP DHSyncManager::CreateManualEvent(/* in */ BOOL bInitialState, /* out */ IHostManualEvent **ppEvent)
{
    DHManualEvent* pEvent = new DHManualEvent(bInitialState);
    if (!pEvent)
    {
        _ASSERTE(!"Failed to allocate a new ManualEvent");
        *ppEvent = NULL;
        return E_OUTOFMEMORY;
    }

    pEvent->QueryInterface(IID_IHostManualEvent, (void**)ppEvent);
    return S_OK;
}

STDMETHODIMP DHSyncManager::CreateMonitorEvent(/* in */ SIZE_T Cookie, /* out */ IHostAutoEvent **ppEvent)
{
    DHAutoEvent* pEvent = new DHAutoEvent(Cookie);
    if (!pEvent)
    {
        _ASSERTE(!"Failed to allocate a new AutoEvent");
        *ppEvent = NULL;
        return E_OUTOFMEMORY;
    }

    pEvent->SetContext(m_pContext);
    pEvent->QueryInterface(IID_IHostAutoEvent, (void**)ppEvent);

    return S_OK;
}

STDMETHODIMP DHSyncManager::CreateRWLockWriterEvent(/* in */ SIZE_T Cookie, /* out */ IHostAutoEvent **ppEvent)
{
    DHAutoEvent* pEvent = new DHAutoEvent(-1);
    if (!pEvent)
    {
        _ASSERTE(!"Failed to allocate a new AutoEvent");
        *ppEvent = NULL;
        return E_OUTOFMEMORY;
    }

    pEvent->QueryInterface(IID_IHostAutoEvent, (void**)ppEvent);
    return S_OK;
}

STDMETHODIMP DHSyncManager::CreateRWLockReaderEvent(/* in */ BOOL bInitialState, /* in */ SIZE_T Cookie, /* out */ IHostManualEvent **ppEvent)
{
    DHAutoEvent* pEvent = new DHAutoEvent(-1);
    if (!pEvent)
    {
        _ASSERTE(!"Failed to allocate a new AutoEvent");
        *ppEvent = NULL;
        return E_OUTOFMEMORY;
    }

    pEvent->QueryInterface(IID_IHostAutoEvent, (void**)ppEvent);
    return S_OK;
}

STDMETHODIMP DHSyncManager::CreateSemaphore(/* in */ DWORD dwInitial, /* in */ DWORD dwMax, /* out */ IHostSemaphore **ppSemaphore)
{
    DHSemaphore* pSemaphore = new DHSemaphore(dwInitial, dwMax);
    if (!pSemaphore)
    {
        _ASSERTE(!"Failed to allocate a new Semaphore");
        *ppSemaphore = NULL;
        return E_OUTOFMEMORY;
    }

    pSemaphore->QueryInterface(IID_IHostSemaphore, (void**)ppSemaphore);
    return S_OK;
}