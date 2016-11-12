#include "stdafx.h"

class DHTask : public IHostTask
{
private:
	volatile LONG m_cRef;
    HANDLE m_hThread;
    DHTaskManager *m_pTaskManager;
    ICLRTask *m_pCLRTask;

public:
    DHTask(DHTaskManager *pTaskManager, HANDLE hThread);
    ~DHTask();

    HANDLE GetThreadHandle() { return m_hThread; };

	// IUnknown functions
	STDMETHODIMP_(DWORD) AddRef();
	STDMETHODIMP_(DWORD) Release();
	STDMETHODIMP QueryInterface(const IID &riid, void **ppvObject);

    // IHostTask functions
    STDMETHODIMP Start();
    STDMETHODIMP Alert();
    STDMETHODIMP Join(/* in */ DWORD dwMilliseconds, /* in */ DWORD dwOption);
    STDMETHODIMP SetPriority(/* in */ int newPriority);
    STDMETHODIMP GetPriority(/* out */ int *pPriority);
    STDMETHODIMP SetCLRTask(/* in */ ICLRTask *pCLRTask);
};