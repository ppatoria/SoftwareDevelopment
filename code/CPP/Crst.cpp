#include "stdafx.h"

// IUnknown functions
DHCrst::DHCrst()
{
    m_cRef = 0;
    m_pCrst = new CRITICAL_SECTION;
    __try
    {
        InitializeCriticalSection(m_pCrst);
    }
    __except (STATUS_NO_MEMORY)
    {
        fprintf(stderr, "Failed to initialize CRST: %d", GetLastError());
        exit(-1);
    }
}

DHCrst::DHCrst(DWORD dwSpinCount)
{
    m_cRef = 0;
    m_pCrst = new CRITICAL_SECTION;
    if (!InitializeCriticalSectionAndSpinCount(m_pCrst, dwSpinCount))
    {
        fprintf(stderr, "Failed to initialize CRST: %d", GetLastError());
        exit(-1);
    }
}

DHCrst::~DHCrst()
{
    if (m_pCrst)
    {
        DeleteCriticalSection(m_pCrst);
        m_pCrst = NULL;
    }
}

STDMETHODIMP_(DWORD) DHCrst::AddRef()
{
    return InterlockedIncrement(&m_cRef);
}

STDMETHODIMP_(DWORD) DHCrst::Release()
{
	ULONG cRef = InterlockedDecrement(&m_cRef);
	if (cRef == 0)
        delete this;
	return cRef;
}

STDMETHODIMP DHCrst::QueryInterface(const IID &riid, void **ppvObject)
{
	if (riid == IID_IUnknown || riid == IID_IHostCrst)
	{
		*ppvObject = this;
		AddRef();
		return S_OK;
	}

	*ppvObject = NULL;
	return E_NOINTERFACE;
}

// IHostCrst functions

STDMETHODIMP DHCrst::Enter(DWORD option)
{
    _ASSERTE(m_pCrst && "Expected a non-null critical section here");

    // TODO: consider 'option' correctly.
    EnterCriticalSection(m_pCrst);
    // TODO: retval transformation

    return S_OK;
}

STDMETHODIMP DHCrst::Leave()
{
    _ASSERTE(m_pCrst && "Expected a non-null critical section here");

    LeaveCriticalSection(m_pCrst);
    // TODO: retval transformation

    return S_OK;
}

STDMETHODIMP DHCrst::TryEnter(DWORD option, BOOL *pbSucceeded)
{
    _ASSERTE(m_pCrst && "Expected a non-null critical section here");

    //TODO consider 'option' correctly.
    *pbSucceeded = TryEnterCriticalSection(m_pCrst);
    // TODO: retval transformation

    return S_OK;
}

STDMETHODIMP DHCrst::SetSpinCount(DWORD dwSpinCount)
{
    _ASSERTE(m_pCrst && "Expected a non-null critical section here");

    SetCriticalSectionSpinCount(m_pCrst, dwSpinCount);
    // TODO: retval transformation

    return S_OK;
}