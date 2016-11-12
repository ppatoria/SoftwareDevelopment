#include "stdafx.h"

// Standard functions

DHSemaphore::DHSemaphore(DWORD dwInitial, DWORD dwMax)
{
    m_cRef = 0;
    m_hSemaphore = CreateSemaphore(NULL, dwInitial, dwMax, NULL);
    if (!m_hSemaphore)
        FailWin32("Failed to create semaphore: %d");
}

DHSemaphore::~DHSemaphore()
{
    if (m_hSemaphore != 0)
    {
        CloseHandle(m_hSemaphore);
        m_hSemaphore = 0;
    }
}

// IUnknown functions

STDMETHODIMP_(DWORD) DHSemaphore::AddRef()
{
    return InterlockedIncrement(&m_cRef);
}

STDMETHODIMP_(DWORD) DHSemaphore::Release()
{
	ULONG cRef = InterlockedDecrement(&m_cRef);
	if (cRef == 0)
        delete this;
	return cRef;
}

STDMETHODIMP DHSemaphore::QueryInterface(const IID &riid, void **ppvObject)
{
	if (riid == IID_IUnknown || riid == IID_IHostSemaphore)
	{
		*ppvObject = this;
		AddRef();
		return S_OK;
	}

	*ppvObject = NULL;
	return E_NOINTERFACE;
}

// IHostSemaphore functions

STDMETHODIMP DHSemaphore::Wait(DWORD dwMilliseconds, DWORD option)
{
    return DHContext::HostWait(m_hSemaphore, dwMilliseconds, option);
}

STDMETHODIMP DHSemaphore::ReleaseSemaphore(LONG lReleaseCount, LONG *lpPreviousCount)
{
    if (!::ReleaseSemaphore(m_hSemaphore, lReleaseCount, lpPreviousCount))
        FailWin32("Failed to release semaphore (%d)");
    return S_OK;
}
