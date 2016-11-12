#include "stdafx.h"

DHHostControl::DHHostControl(ICLRRuntimeHost *pRuntimeHost)
{
	m_cRef = 0;
	m_pRuntimeHost = pRuntimeHost;
    m_pRuntimeHost->AddRef();

    if (!SUCCEEDED(pRuntimeHost->GetCLRControl(&m_pRuntimeControl)))
    {
        fprintf(stderr, "Failed to obtain a CLR Control object");
        exit(-1);
    }

    m_pContext = new DHContext();
    m_pTaskManager = new DHTaskManager(m_pContext);
    m_pSyncManager = new DHSyncManager(m_pContext);

    if (!m_pContext || !m_pTaskManager || !m_pSyncManager)
    {
        fprintf(stderr, "Context or manager allocation failed");
        exit(-1);
    }

    m_pTaskManager->AddRef();
    m_pSyncManager->AddRef();
    m_pContext->SetTaskManager(m_pTaskManager);
    m_pContext->SetSyncManager(m_pSyncManager);

}

DHHostControl::~DHHostControl()
{
    delete m_pContext;
    m_pRuntimeHost->Release();
    m_pRuntimeControl->Release();
    m_pTaskManager->Release();
    m_pSyncManager->Release();
}

STDMETHODIMP_(VOID) DHHostControl::ShuttingDown()
{
#if LOCK_TRACE
    map<SIZE_T, vector<SIZE_T>*> *pTrace = m_pContext->GetLockTrace();

    fprintf(stdout, "------------------------------\r\n");
    fprintf(stdout, "Dumping lock trace information\r\n");
    fprintf(stdout, "------------------------------\r\n");
    for (map<SIZE_T, vector<SIZE_T>*>::iterator trace = pTrace->begin();
        trace != pTrace->end();
        trace++)
    {
        fprintf(stdout, "LOCK %d: ", trace->first);
        for (vector<SIZE_T>::iterator innerTrace = trace->second->begin();
            innerTrace != trace->second->end();
            innerTrace++)
        {
            fprintf(stdout, " %d ", *innerTrace);
        }
        fprintf(stdout, "\r\n");
        delete trace->second;
    }

#endif
}

// IUnknown functions

STDMETHODIMP_(DWORD) DHHostControl::AddRef()
{
    return InterlockedIncrement(&m_cRef);
}

STDMETHODIMP_(DWORD) DHHostControl::Release()
{
	ULONG cRef = InterlockedDecrement(&m_cRef);
	if (cRef == 0)
        delete this;
	return cRef;
}

STDMETHODIMP DHHostControl::QueryInterface(const IID &riid, void **ppvObject)
{
	if (riid == IID_IUnknown || riid == IID_IHostControl)
	{
		*ppvObject = this;
		AddRef();
		return S_OK;
	}

	*ppvObject = NULL;
	return E_NOINTERFACE;
}

// IHostControl functions

STDMETHODIMP DHHostControl::GetHostManager(const IID &riid, void **ppvHostManager)
{
	if (riid == IID_IHostTaskManager)
        m_pTaskManager->QueryInterface(IID_IHostTaskManager, ppvHostManager);
    else if (riid == IID_IHostSyncManager)
        m_pSyncManager->QueryInterface(IID_IHostSyncManager, ppvHostManager);
    else
    	ppvHostManager = NULL;

	return S_OK;
}

STDMETHODIMP DHHostControl::SetAppDomainManager(DWORD dwAppDomainID, IUnknown *pUnkAppDomainManager)
{
    _ASSERTE(!"Not implemented");
	return E_NOTIMPL;
}