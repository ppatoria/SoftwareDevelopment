/*
 * Types of indication events.
 * These values are powers of two so their bits can be “or’d” together efficiently.
 */
enum 
{
    READ_EVENT		= 01,    // ACCEPT_EVENT aliases READ_EVENT
    ACCEPT_EVENT	= 01,	 // due to <select> semantics.
    WRITE_EVENT		= 02, 
    TIMEOUT_EVENT	= 04,
    SIGNAL_EVENT	= 010, 
    CLOSE_EVENT		= 020    
};

/*
 * Single-method interface.
 */
class Event_Handler 
{
public:
    /*    
     * Hook method dispatched by <Reactor> to handle events of a particular type.
     */
    virtual void handle_event (HANDLE handle, Event_Type et) = 0;
    /*
     * Hook method that returns the I/O <HANDLE>.
     */
    virtual HANDLE get_handle () const = 0;
protected:
    /*
     * Virtual destructor is protected to ensure dynamic allocation.
     */
    virtual ~Event_Handler ();
};

/*
 * Hook methods dispatched by a <Reactor> to handle particular types of events.
 */
class Event_Handler {
public:
    virtual void   handle_input   (HANDLE handle) = 0;
    virtual void   handle_output  (HANDLE handle) = 0;
    virtual void   handle_timeout (const Time_Value &) = 0;
    virtual void   handle_close   (HANDLE handle, Event_Type et) = 0;
    virtual HANDLE get_handle     () const = 0; // Hook method that returns the I/O <HANDLE>.
};

/*
 * Methods that register and remove <Event_Handler>s 
 * of particular <Event_Type>s on a <HANDLE>.
 */
class Reactor 
{
public:
    virtual void register_handler (Event_Handler *eh, Event_Type et) = 0;
    virtual void register_handler (HANDLE h, Event_Handler *eh, Event_Type et) = 0;
    virtual void remove_handler   (Event_Handler *eh, Event_Type et) = 0;
    virtual void remove_handler   (HANDLE h, Event_Type et) = 0; 
    /*
     * Entry point into the reactive event loop. 
     * The <timeout> can bound time waiting for events.
     */
    void handle_events (Time_Value *timeout = 0);   
    /*
     * Define a singleton access point.
     */
    static Reactor *instance ();
private:
    /*
     * Use the Bridge pattern to hold a pointer to the <Reactor_Implementation>.
     */
    Reactor_Implementation *reactor_impl_;
};

void Select_Reactor_Implementation::register_handler (Event_Handler *event_handler,
						      Event_Type event_type) 
{
    HANDLE handle = event_handler->get_handle (); // Double-dispatch to obtain the <HANDLE>.
    // …
}

int select (u_int max_handle_plus_1,
	    fd_set *read_fds, fd_set *write_fds,
	    fd_set *except_fds,timeval *timeout);

class Demux_Table 
{
public:
    /*
     * Convert <Tuple> array to <fd_set>s.
     */
    void convert_to_fd_sets (fd_set &read_fds,
			     fd_set &write_fds,
			     fd_set &except_fds);
 
    struct Tuple 
    {
	/*
	 * Pointer to <Event_Handler> that processes
	 * the indication events arriving on the handle.
	 */
	Event_Handler *event_handler_;
 
	/*
	 * Bit-mask that tracks which types of indication
	 * events <Event_Handler> is registered for.
	 */
	Event_Type event_type_;
    };
    /*
     * Table of <Tuple>s indexed by Handle values. The
     * macro FD_SETSIZE is typically defined in the
     * <sys/socket.h> system header file.
     */
    Tuple table_[FD_SETSIZE];
};

class Select_Reactor_Implementation : public Reactor_Implementation 
{
public:

    /*
     * The handle_events() method defines the entry point into the 
     * reactive event loop of our Select_Reactor_Implementation:
     */
    void Select_Reactor_Implementation::handle_events (Time_Value *timeout = 0) 
    {
        /*
	 *This method first converts the Demux_Table tuples into fd_set handle sets 
	 * that can be passed to select():
         */
	fd_set read_fds, write_fds, except_fds;
 
	demuxtable.convert_to_fd_sets (read_fds, 
				       write_fds, 
				       except_fds);

	/*
	 * Next, select() is called to wait for up to timeout amount of time 
	 * for indication events to occur on the handle sets:
	 */
	HANDLE max_handle = n; // Max value in <fd_set>s.
	int result = select (max_handle + 1,
			     &read_fds, 
			     &write_fds, 
			     &except_fds,
			     timeout);
 
	if (result <= 0)
	    throw /* handle error or timeout cases */;

        /*
	 * Finally, we iterate over the handle sets and dispatch the hook method(s) 
	 * on event handlers whose handles have become ‘ready’ due to the occurrence 
	 * of indication events:
	 */
	for (HANDLE h = 0; h <= max_handle; ++h) {
	    /*         
	     * This check covers READ_ + ACCEPT_EVENTs
	     * because they have the same enum value.
	     */
	    if (FD_ISSET (&read_fds, h))
		demux_table.table_[h].event_handler_-> handle_event (h, READ_EVENT);
 	    // … perform the same dispatching logic for
	    // WRITE_EVENTs and EXCEPT_EVENTs …
	}
    }
    /*
     * For brevity, we omit implementations of other methods in our reactor, 
     * for example those for registering and unregistering event handlers.
     * 
     * The private portion of our reactor class maintains the event handler 
     * demultiplexing table:
     */
private:
    /*   
     * Demultiplexing table that maps <HANDLE>s to
     * <Event_Handler>s and <Event_Type>s.
     */
    Demux_Table demux_table_;
};





