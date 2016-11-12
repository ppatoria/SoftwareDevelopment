#include <msclr/marshal.h>
#include <string>
#include <wchar.h>
#include <time.h>
 
using namespace System;
using namespace System::Runtime::InteropServices;
 
class NativeEmployee 
{
public:
    NativeEmployee(const wchar_t *employeeName, int age)
        : _employeeName(employeeName), _employeeAge(age) { }
 
    void DoWork(const wchar_t **tasks, int numTasks) 
        {
            for (int i = 0; i < numTasks; i++) 
            {
                wprintf(L"Employee %s is working on task %s\n",
                        _employeeName.c_str(), tasks[i]);
            }
        }
 
    int GetAge() const 
        {
            return _employeeAge;
        }
 
    const wchar_t *GetName() const 
        {
            return _employeeName.c_str();
        }
 
private:
    std::wstring _employeeName;
    int _employeeAge;
};
 
#pragma managed
 
namespace EmployeeLib 
{
  public ref class Employee 
  {
  public:
      Employee(String ^employeeName, int age) 
          {
              //OPTION 1:
              //IntPtr pEmployeeName = Marshal::StringToHGlobalUni(employeeName);
              //m_pEmployee = new NativeEmployee(
              // reinterpret_cast<wchar_t *>(pEmployeeName.ToPointer()), age);
              //Marshal::FreeHGlobal(pEmployeeName);
 
              //OPTION 2 (direct pointer to pinned managed string, faster):
              pin_ptr<const wchar_t> ppEmployeeName = PtrToStringChars(employeeName);
              _employee = new NativeEmployee(ppEmployeeName, age);
          }
 
       Employee() 
          {
              delete _employee;
              _employee = nullptr;
          }
      int GetAge() 
          {
              return _employee->GetAge();
          }
 
      String ^GetName() 
          {
              //OPTION 1:
              //return Marshal::PtrToStringUni(
              // (IntPtr)(void *) _employee->GetName());
 
              //OPTION 2:
              return msclr::interop::marshal_as<String ^>(_employee->GetName());
              //OPTION 3 (faster):
              return gcnew String(_employee->GetName());
          }
 
      void DoWork(array<String^>^ tasks) 
          {
              //marshal_context is a managed class allocated (on the GC heap)
              //using stack-like semantics. Its IDisposable::Dispose()/d’tor will
              //run when exiting scope of this function.
              msclr::interop::marshal_context ctx;
              const wchar_t **pTasks = new const wchar_t*[tasks->Length];
              for (int i = 0; i < tasks->Length; i++) {
                  String ^t = tasks[i];
                  pTasks[i] = ctx.marshal_as<const wchar_t *>(t);
              }
              m_pEmployee->DoWork(pTasks, tasks->Length);
              //context d’tor will release native memory allocated by marshal_as
              delete[] pTasks;
          }
 
  private:
      NativeEmployee *_employee;
  };
}
