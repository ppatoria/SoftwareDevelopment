#include "stdafx.h"

class DHTaskManager;
class DHSyncManager;

class DHHostControl : public IHostControl
{
private:
	volatile LONG m_cRef;
	ICLRRuntimeHost *m_pRuntimeHost;
    ICLRControl *m_pRuntimeControl;
    DHContext *m_pContext;
    DHTaskManager *m_pTaskManager;
    DHSyncManager *m_pSyncManager;
public:
	DHHostControl(ICLRRuntimeHost *pRuntimeHost);
    ~DHHostControl();

    ICLRControl* GetCLRControl() { return m_pRuntimeControl; };
    STDMETHODIMP_(VOID) ShuttingDown();

	// IUnknown functions
	STDMETHODIMP_(DWORD) AddRef();
	STDMETHODIMP_(DWORD) Release();
	STDMETHODIMP QueryInterface(const IID &riid, void **ppvObject);

	// IHostControl functions
	STDMETHODIMP GetHostManager(const IID &riid, void **ppObject);
	STDMETHODIMP SetAppDomainManager(DWORD dwAppDomainID, IUnknown *pUnkAppDomainManager);
};