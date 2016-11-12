#include <iostream>
#include <functional>

using namespace std;

class Service{
public:
    void RegisterListener(function<void (string)> msgListener)
	{
	    MsgListener = msgListener;
	}

    void OnMessage(string msg)
	{
	    MsgListener (msg);
	}
private:
    function<void (string)> MsgListener;
};

int main ()
{
    Service s;
    string closer_var = "closer";
    s.RegisterListener ([&] (string msg)
			{
			    cout << msg << " " << closer_var << endl;
			});
    s.OnMessage ("test");
    return 0;
}    
