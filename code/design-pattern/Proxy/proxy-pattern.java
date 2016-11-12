// The proxy.
public class LargeHashtable extends Hashtable 
{
    // The ReferenceCountedHashTable that this is a proxy for.
    private ReferenceCountedHashTable theHashTable;
    
    // Constructor
    public LargeHashtable() 
        {
            theHashTable = new ReferenceCountedHashTable();
        }

    // Return the number of key-value pairs in this hashtable.
    public int size() 
        {
            return theHashTable.size();
        }

    // Return the value associated with the specified key.
    public synchronized Object get(Object key) 
        {
            return theHashTable.get(key);
        }

    // Add the given key-value pair to this Hashtable.
    public synchronized Object put(Object key, Object value) 
        {
            copyOnWrite();
            return theHashTable.put(key, value);
        }

    // Return a copy of this proxy that accesses the same Hashtable.
    public synchronized Object clone() 
        {
            Object copy = super.clone();
            theHashTable.addProxy();
            return copy;
        }

    // This method is called before modifying the underlying
    // Hashtable. If it is being shared then this method clones it.
    private void copyOnWrite() 
        {
            if (theHashTable.getProxyCount() > 1) 
            {
                synchronized (theHashTable) 
                {
                    theHashTable.removeProxy();
                    try 
                    {
                        theHashTable = (ReferenceCountedHashTable) theHashTable.clone();
                    } 
                    catch (Throwable e) 
                    {
                        theHashTable.addProxy();
                    }
                }
            }
        }

    // Private class to keep track of proxies sharing the hash table.
    private class ReferenceCountedHashTable extends Hashtable 
    {
        private int proxyCount = 1;

        // Constructor
        public ReferenceCountedHashTable() 
            {
                super();
            }

        // Return a copy of this object with proxyCount set back to 1.
        public synchronized Object clone() 
            {
                ReferenceCountedHashTable copy;
                copy = (ReferenceCountedHashTable)super.clone();
                copy.proxyCount = 1;
                return copy;
            }

        // Return the number of proxies using this object.
        synchronized int getProxyCount() 
            {
                return proxyCount;
            }

        // Increment the number of proxies using this object by one.
        synchronized void addProxy() 
            {
                proxyCount++;
            }
        
        // Decrement the number of proxies using this object by one.
        synchronized void removeProxy() 
            {
                proxyCount--;
            }
    }
}