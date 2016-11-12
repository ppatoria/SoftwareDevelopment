class HANDLE{};
class Event_Type{};
    
class Event_Handler 
{
public:
    /*    
    * Hook method dispatched by <Reactor> to handle
    * events of a particular type.
    */
//     virtual void handle_event (HANDLE handle, Event_Type et) = 0;
//     /*
//      * Hook method that returns the I/O <HANDLE>.
//      */
//     virtual HANDLE get_handle () const = 0;
 protected:
    /*
     * Virtual destructor is protected to ensure
     * dynamic allocation.
     */
    virtual ~Event_Handler ();
};

class derived : public Event_Handler
{
public:
    // void handle_event (HANDLE handle, Event_Type et)
    // 	{	
    // 	}

    // HANDLE get_handle ()
    // 	{
    // 	    HANDLE h;
    // 	    return h;
    // 	}
};

int main (){
    
    //Event_Handler* b = new derived ();
    derived* d = new derived ();
    delete d;
};
    
