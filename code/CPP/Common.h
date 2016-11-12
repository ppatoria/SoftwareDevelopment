#ifndef __HOSTCOMMON__H__
#define __HOSTCOMMON__H__

#include "mscoree.h"
#include "corhlpr.h"
#include "Context.h"
#include "CrstLock.h"
#include "HostCtrl.h"
#include "SyncMgr.h"
#include "Crst.h"
#include "Event.h"
#include "Semaphore.h"
#include "Task.h"
#include "TaskMgr.h"

void Fail(const char *msg);
void FailWin32(const char *msg);
void CheckFail(HRESULT hr, const char *msg);

#endif