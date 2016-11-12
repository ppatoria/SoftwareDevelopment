class publisher 
{
    list client_list;

    register (client c)
	{
	    client_list.add (c)
	}

    unregister (client c)
	{
	    client_list.remove (c);
	}

    process()
	{	    
	    foreach (client c in client_list)
		c.on_event(data)
	}
}

class subscriber : ISubscriptionEnvent
{
    subscriber (publisher p)
	{	
	    p.register(this);
	}
    
    on_event(data)
	{
	    // ....
	}    
}

class program
{
    main()
	{
	    publisher p = new publisher();
	    subscriber s1 = new subscriber(p);
	    subscriber s2 = new subscriber(p);
	    p.process();

	}
}