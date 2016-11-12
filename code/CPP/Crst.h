#include "stdafx.h"

class DHCrst : public IHostCrst
{
private:
	volatile LONG m_cRef;
    CRITICAL_SECTION* m_pCrst;
public:
    DHCrst();
	DHCrst(DWORD dwSpinCount);
	~DHCrst();

	// IUnknown functions
	STDMETHODIMP_(DWORD) AddRef();
	STDMETHODIMP_(DWORD) Release();
	STDMETHODIMP QueryInterface(const IID &riid, void **ppvObject);

    // IHostCrst functions
    STDMETHODIMP Enter(DWORD option);
    STDMETHODIMP Leave();
    STDMETHODIMP TryEnter(DWORD option, BOOL *pbSucceeded);
    STDMETHODIMP SetSpinCount(DWORD dwSpinCount);
};