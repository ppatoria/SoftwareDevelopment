#include <iostream>
#include <vector>
#include <algorithm>

using namespace std;

class status 
{
    string name_;
    bool ok_;

public:
    status(const string& name)
        :name_(name), ok_(true) 
        {}

    void break_it() 
        {
            ok_=false;
        }

    bool is_broken() const 
        {
            return ok_;
        }

    void report() const 
        {
            cout << name_ << " is " <<
                (ok_ ? "working nominally":"terribly broken") << '\n';
        }

    void report1(status& state) const 
        {
            state.report();
        }
};


class report_generator
{
public:
    void operator () (status& state){
        state.report();
    }
};

int main()
{
    vector<status> statuses;
    statuses.push_back(status("status 1"));
    statuses.push_back(status("status 2"));
    statuses.push_back(status("status 3"));
    statuses.push_back(status("status 4"));

    statuses[1].break_it();
    statuses[2].break_it();

    cout << endl << "for with iterator" << endl << endl;

    for (vector<status>::iterator it = statuses.begin(); 
         it!=statuses.end(); ++it) 
    {
        it->report();
    }

    cout << endl << "for_each with mem_fun_ref " << endl << endl;

    for_each(
    	statuses.begin(),
        statuses.end(),
        mem_fun_ref(&status::report));

    cout << endl << "for_each with functor" << endl << endl;

    report_generator generateReport;
    for_each(
        statuses.begin(),
        statuses.end(),
        generateReport);

    cout << endl << "for_each with mem_fun_ref and report1" << endl << endl;

    for_each(
        statuses.begin(),
        statuses.end(),
        mem_fun_ref(&status::report1));



    return 0;
}
