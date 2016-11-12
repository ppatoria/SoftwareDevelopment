#include <thread> 
#include <mutex> 
#include <condition_variable> 
#include <string>

using namespace std:

typename uniq_mutex_lock

class ThreadPool;
class Worker						// our worker thread objects 
{ 
public:     
    Worker (ThreadPool &s) : pool(s) { }     
    void operator () ();
    
private:     
    ThreadPool &pool;
};

class ThreadPool					// the actual thread pool 
{ 
public:     
    ThreadPool (size_t);
    template <class F> 
    void enqueue (F f);
    ~ThreadPool	 ();
private:     
    friend class Worker;
    
    vector <thread> workers;				// need to keep track of threads so we can join them         
    deque <function<void()>> tasks;			// the task queue         
    mutex queue_mutex;					// synchronization     
    condition_variable condition;
    bool stop;
};


void Worker::operator () () {
    function<void ()> task;     
    while(true){         	  	
	uniq_mutex_lock lock (pool.queue_mutex);	// acquire lock             
	while( !pool.stop 	    
	       && 	    
	       pool.tasks.empty ()) 
	{						// look for a work item             	             
	    pool.condition.wait (lock);			// if there are none wait for notification                 
	}             
	if (pool.stop)					// exit if the pool is stopped                
	    return;             	
	task = pool.tasks.front ();			// get the task from the queue             
	pool.tasks.pop_front ();				// release lock         
    }       
    task ();						// execute the task         
} 

