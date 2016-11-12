#include "stdafx.h"

class DHTask;
class DHTaskManager;
class DHSyncManager;

typedef map<DHTask*, SIZE_T> DHDetails;

class DHContext
{
private:
    DHTaskManager *m_pTaskManager;
    DHSyncManager *m_pSyncManager;
    map<IHostTask*, SIZE_T> *m_pLockWaits;
    LPCRITICAL_SECTION m_pCrst;

#if LOCK_TRACE
    DWORD m_dwTlsCurrentLocks;
    map<SIZE_T, vector<SIZE_T>*> *m_pLockTrace;
    LPCRITICAL_SECTION m_pLockTraceCrst;
#endif

public:
    DHContext();
    ~DHContext();

    map<SIZE_T, vector<SIZE_T>*>* GetLockTrace() { return m_pLockTrace; };
    static HRESULT HostWait(HANDLE hWait, DWORD dwMilliseconds, DWORD dwOption);
    void PrintDeadlock(DHDetails *pDetails, SIZE_T cookie);

    STDMETHODIMP_(VOID) SetTaskManager(DHTaskManager *pTaskManager);
    STDMETHODIMP_(VOID) SetSyncManager(DHSyncManager *pSyncManager);

    STDMETHODIMP_(DHDetails*) TryEnter(SIZE_T cookie);
    STDMETHODIMP_(VOID) EndEnter(SIZE_T cookie);
    STDMETHODIMP_(VOID) Release(SIZE_T cookie);
    STDMETHODIMP_(DHDetails*) DetectDeadlock(SIZE_T cookie);
};