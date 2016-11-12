class singleton
{
    private static readonly object locker = new object ();
    private static singleton_;

    private singleton ()
	{	
	}

    public static getInstanceExpensive ()
	{
	    lock (locker)
	    {
		if (singleton_ == null)
		    singleton_ = new singleton ();
		return singleton_
		    }	    
	}

    public static getInstance ()
	{
	    if (singleton_ == null)		
	    {	
		lock (locker)
		{
		    if (singleton_ == null)
			singleton_ = new singleton ();
		}
	    }
	    else
	    {		
	        return singleton_;
	    }
	}
}