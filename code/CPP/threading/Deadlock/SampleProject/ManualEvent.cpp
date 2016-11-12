#include "stdafx.h"

// Standard functions

DHManualEvent::DHManualEvent(BOOL bInitialState)
{
    m_cRef = 0;
    m_hEvent = CreateEvent(NULL, TRUE, bInitialState, NULL);
    if (!m_hEvent)
        FailWin32("Error creating manual event: %d");
    m_pContext = NULL;
}

DHManualEvent::~DHManualEvent()
{
    if (m_hEvent)
    {
        CloseHandle(m_hEvent);
        m_hEvent = NULL;
    }
}

// IUnknown functions

STDMETHODIMP_(DWORD) DHManualEvent::AddRef()
{
    return InterlockedIncrement(&m_cRef);
}

STDMETHODIMP_(DWORD) DHManualEvent::Release()
{
	ULONG cRef = InterlockedDecrement(&m_cRef);
	if (cRef == 0)
        delete this;
	return cRef;
}

STDMETHODIMP DHManualEvent::QueryInterface(const IID &riid, void **ppvObject)
{
	if (riid == IID_IUnknown || riid == IID_IHostManualEvent)
	{
		*ppvObject = this;
		AddRef();
		return S_OK;
	}

	*ppvObject = NULL;
	return E_NOINTERFACE;
}

// IHostManualEvent functions

STDMETHODIMP DHManualEvent::Set()
{
    if (!SetEvent(m_hEvent))
    {
        _ASSERTE(false && "SetEvent failed");
        return HRESULT_FROM_WIN32(GetLastError());
    }

    return S_OK;
}

STDMETHODIMP DHManualEvent::Reset()
{
    if (!ResetEvent(m_hEvent))
    {
        _ASSERTE(false && "ResetEvent failed");
        return HRESULT_FROM_WIN32(GetLastError());
    }

    return S_OK;
}

STDMETHODIMP DHManualEvent::Wait(DWORD dwMilliseconds, DWORD option)
{
    return DHContext::HostWait(m_hEvent, dwMilliseconds, option);
}