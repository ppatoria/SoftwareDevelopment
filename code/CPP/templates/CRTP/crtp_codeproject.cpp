class AbstractTextout
{
public:
    void Print(const wchar_t* fmt);
    // ... plus 10 other overloaded Print with different number of Box arguments
protected:
    virtual void Process(const std::wstring& str) = 0;
};

void AbstractTextout::Print(const wchar_t* fmt, Box D1)
{
    std::wstring wsfmtstr = fmt;
    std::vector<std::wstring> vs;
    vs.push_back( D1.ToString() );
    std::wstring str = StrReplace( wsfmtstr, vs );
    Process(str); // implemented in the derived class only.
}

void Process(const std::wstring& str)
{
#ifdef _DEBUG
    OutputDebugStringW( str.c_str() );
#endif
}#include "DebugPrint.h"

void main()
{
    DebugPrint dp;
    dp.Print(L"Product:{0}, Qty:{1}, Price is ${2}\n", L"Shampoo", 1200, 2.65);
    // display "Product:Shampoo, Qty:1200, Price is $2.650000"
}
/*-------------------------------------------------------------------------------------------------*/

template <typename Derived> 
class AbstractTextout
{
public:
    void Print(const wchar_t* fmt, Box D1 ){
	std::wstring wsfmtstr = fmt;
	std::vector<std::wstring> vs;
	vs.push_back( D1.ToString() );
	std::wstring str = StrReplace( wsfmtstr, vs );
	static_cast<Derived*>(this)->Process(str);
    }
};

class DebugPrint : public AbstractTextout<DebugPrint>
{
public:
    void Process(const std::wstring& str){
#ifdef _DEBUG
	OutputDebugStringW( str.c_str() );
#endif
    }
};

#include "DebugPrint.h"
void main(){
    DebugPrint dp;
    dp.Print(L"Product:{0}, Qty:{1}, Price is ${2}\n", L"Shampoo", 1200, 2.65);
    // display "Product:Shampoo, Qty:1200, Price is $2.650000"
}
