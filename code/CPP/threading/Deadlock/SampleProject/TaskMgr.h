#include "stdafx.h"

class DHContext;

class DHTaskManager : public IHostTaskManager
{
private:
	volatile LONG m_cRef;
    ICLRTaskManager *m_pCLRTaskManager;
    map<DWORD, IHostTask*> *m_pThreadMap;
    LPCRITICAL_SECTION m_pThreadMapCrst;
    DHContext *m_pContext;
    HANDLE m_hSleepEvent;

public:
    DHTaskManager(DHContext *pContext);
    ~DHTaskManager();

	// IUnknown functions
	STDMETHODIMP_(DWORD) AddRef();
	STDMETHODIMP_(DWORD) Release();
	STDMETHODIMP QueryInterface(const IID &riid, void **ppvObject);

	// IHostTaskManager functions
    STDMETHODIMP GetCurrentTask(/* out */ IHostTask **pTask);
    STDMETHODIMP CreateTask(/* in */ DWORD dwStackSize, /* in */ LPTHREAD_START_ROUTINE pStartAddress, /* in */ PVOID pParameter, /* out */ IHostTask **ppTask);
    STDMETHODIMP Sleep(/* in */ DWORD dwMilliseconds, /* in */ DWORD option);
    STDMETHODIMP SwitchToTask(/* in */ DWORD option);
    STDMETHODIMP SetUILocale(/* in */ LCID lcid);
    STDMETHODIMP SetLocale(/* in */ LCID lcid);
    STDMETHODIMP CallNeedsHostHook(/* in */ SIZE_T target, /* out */ BOOL *pbCallNeedsHostHook);
    STDMETHODIMP LeaveRuntime(/* in */ SIZE_T target);
    STDMETHODIMP EnterRuntime();
    STDMETHODIMP ReverseEnterRuntime();
    STDMETHODIMP ReverseLeaveRuntime();
    STDMETHODIMP BeginDelayAbort();
    STDMETHODIMP EndDelayAbort();
    STDMETHODIMP BeginThreadAffinity();
    STDMETHODIMP EndThreadAffinity();
    STDMETHODIMP SetStackGuarantee(/* in */ ULONG guarantee);
    STDMETHODIMP GetStackGuarantee(/* out */ ULONG *pGuarantee);
    STDMETHODIMP SetCLRTaskManager(/* in */ ICLRTaskManager *pManager);
};