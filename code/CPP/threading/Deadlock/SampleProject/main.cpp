#include "stdafx.h"

void Fail(const char *msg)
{
    fprintf(stderr, msg);
    exit(-1);
}

void FailWin32(const char *msg)
{
    fprintf(stderr, msg, GetLastError());
    exit(-1);
}

void CheckFail(HRESULT hr, const char *msg)
{
    if (!SUCCEEDED(hr))
    {
        fprintf(stderr, msg, hr);
        exit(-1);
    }
}

int _tmain(int argc, _TCHAR* argv[])
{
	// Bind to the runtime.
	ICLRRuntimeHost *pClrHost = NULL;
	HRESULT hrCorBind = CorBindToRuntimeEx(
		NULL,   // Load the latest CLR version available
		L"wks", // Workstation GC ("wks" or "svr" overrides)
		0,      // No flags needed
		CLSID_CLRRuntimeHost,
		IID_ICLRRuntimeHost,
		(PVOID*)&pClrHost);
    CheckFail(hrCorBind, "Bind to runtime failed (0x%x)");

	// Construct our host control object.
    DHHostControl *pHostControl = new DHHostControl(pClrHost);
	if (!pHostControl)
        Fail("Host control allocation failed");
	pClrHost->SetHostControl(pHostControl);

	// Now, begin the CLR.
	HRESULT hrStart = pClrHost->Start();
    if (hrStart == S_FALSE)
        _ASSERTE(!L"Runtime already started; probably OK to proceed");
    else
        CheckFail(hrStart, "Runtime startup failed (0x%x)");

    // Construct the shim path (i.e. shim.exe).
	WCHAR wcShimPath[MAX_PATH];
    if (!GetCurrentDirectoryW(MAX_PATH, wcShimPath))
        CheckFail(HRESULT_FROM_WIN32(GetLastError()), "GetCurrentDirectory failed (0x%x)");
    wcsncat_s(wcShimPath, sizeof(wcShimPath) / sizeof(WCHAR), L"\\shim.exe", MAX_PATH - wcslen(wcShimPath) - 1);

    // Gather the arguments to pass to the shim.
    LPWSTR wcShimArgs = NULL;
    if (argc > 1)
    {
        SIZE_T totalLength = 1; // 1 is the NULL terminator
        for(int i = 1; i < argc; i++)
        {
            // TODO: add characters for quotes around args w/ spaces inside them
            if (i != 1)
                totalLength++; // add a space between args
            totalLength += _tcslen(argv[i]) + 1;
		}

        wcShimArgs = new WCHAR[totalLength];
        wcShimArgs[0] = '\0';
 
        for(int i = 1; i < argc; i++)
        {
            if (i != 1)
                wcscat_s(wcShimArgs, totalLength, L" ");
            wcsncat_s(wcShimArgs, totalLength, argv[i], wcslen(argv[i]));
		}
	}

    if (wcShimArgs == NULL)
        Fail("Missing program path (host.exe <exePath>)\r\n");

	// And execute the program...
    DWORD retVal;
    HRESULT hrExecute = pClrHost->ExecuteInDefaultAppDomain(
        wcShimPath,
        L"Shim",
        L"Start",
        wcShimArgs,
        &retVal);
    CheckFail(hrExecute, "Execution of shim failed (0x%x)\r\n");

    if (wcShimArgs)
        delete wcShimArgs;

    // Stop the CLR and cleanup.
    pHostControl->ShuttingDown();
    pClrHost->Stop();
    pClrHost->Release();

	return retVal;
}