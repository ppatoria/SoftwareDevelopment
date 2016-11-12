#include "stdafx.h"

class DHAutoEvent : public IHostAutoEvent
{
private:
	volatile LONG m_cRef;
    HANDLE m_hEvent;
    SIZE_T m_cookie;
    DHContext *m_pContext;

public:
    DHAutoEvent(SIZE_T cookie);
    ~DHAutoEvent();

    void SetContext(DHContext *pContext) { m_pContext = pContext; };

	// IUnknown functions
    STDMETHODIMP_(DWORD) AddRef();
    STDMETHODIMP_(DWORD) Release();
    STDMETHODIMP QueryInterface(const IID &riid, void **ppvObject);

    // IHostAutoEvent functions
    STDMETHODIMP Wait(DWORD dwMilliseconds, DWORD option);
    STDMETHODIMP Set();
};

class DHManualEvent : public IHostManualEvent
{
private:
	volatile LONG m_cRef;
    HANDLE m_hEvent;
    DHContext *m_pContext;
public:
    DHManualEvent(BOOL bInitialState);
    ~DHManualEvent();

    void SetContext(DHContext *pContext) { m_pContext = pContext; };

	// IUnknown functions
    STDMETHODIMP_(DWORD) AddRef();
    STDMETHODIMP_(DWORD) Release();
    STDMETHODIMP QueryInterface(const IID &riid, void **ppvObject);

    // IHostManualEvent functions
    STDMETHODIMP Wait(DWORD dwMilliseconds, DWORD option);
    STDMETHODIMP Reset();
    STDMETHODIMP Set();
};