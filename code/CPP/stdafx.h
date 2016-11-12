// stdafx.h : include file for standard system include files,
// or project specific include files that are used frequently, but
// are changed infrequently
//

#pragma once


#define WIN32_LEAN_AND_MEAN		// Exclude rarely-used stuff from Windows headers

#ifndef _WIN32_WINNT
#define _WIN32_WINNT 0x0500
#endif

#define LOCK_TRACE 0xCAFEBABE

#include <stdio.h>
#include <tchar.h>

// TODO: reference additional headers your program requires here
#include <assert.h>
#include <list>
#include <map>
#include <vector>

using namespace std;

#include "Common.h"
