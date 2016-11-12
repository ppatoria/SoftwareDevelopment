#include "stdafx.h"

class DHSemaphore : public IHostSemaphore
{
private:
	volatile LONG m_cRef;
    HANDLE m_hSemaphore;
public:
	DHSemaphore(DWORD dwInitial, DWORD dwMax);
    ~DHSemaphore();

	// IUnknown functions
	STDMETHODIMP_(DWORD) AddRef();
	STDMETHODIMP_(DWORD) Release();
	STDMETHODIMP QueryInterface(const IID &riid, void **ppvObject);

    // IHostSemaphore functions
    STDMETHODIMP Wait(DWORD dwMilliseconds, DWORD option);
    STDMETHODIMP ReleaseSemaphore(LONG lReleaseCount, LONG *lpPreviousCount);
};