#include <iostream>
#include "boost/thread/thread.hpp"
#include "boost/thread/mutex.hpp"
#include "boost/thread/tss.hpp"

using namespace std;
using namespace boost;

class hierarchical_mutex
{
    mutex               internal_mutex;
    unsigned long const hierarchy_value;
    unsigned long       previous_hierarchy_value;

    static thread_specific_ptr<unsigned long> this_thread_hierarchy_value;

    void check_for_hierarchy_violation ()
	{
	    if(*this_thread_hierarchy_value <= hierarchy_value)
	    {
		throw logic_error("mutex hierarchy violated");
	    }
	}

    void update_hierarchy_value ()
	{
            previous_hierarchy_value     =  *this_thread_hierarchy_value;
	    this_thread_hierarchy_value.reset(new unsigned long(hierarchy_value));
	}

public:
    explicit hierarchical_mutex (unsigned long value) :	
	hierarchy_value (value),
	previous_hierarchy_value (0)
	{}

    void lock ()
	{
	    check_for_hierarchy_violation ();
	    internal_mutex.lock ();
	    update_hierarchy_value ();
	}

    void unlock ()
	{
            this_thread_hierarchy_value.reset(new unsigned long(previous_hierarchy_value));
	    internal_mutex.unlock ();
	}
   
    bool try_lock()
	{
	    check_for_hierarchy_violation ();
	    if (!internal_mutex.try_lock())
		return false;
	    update_hierarchy_value ();
	    return true;
	}    
};
