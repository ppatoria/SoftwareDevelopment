internal sealed class ThreadsSharingData 
{
    private Int32 m_flag  = 0;
    private Int32 m_value = 0;
    
    public void Thread1() {  // This method is executed by one thread
       m_value = 5;          // Note: These could execute in reverse order
       m_flag  = 1;
    }
   
    public void Thread2() {  // This method is executed by another thread
        if (m_flag == 1)
            Console.WriteLine(m_value);
   }
}

/** 
 ** The Volatile.Write method forces the value in location to be written to at the point of the call. 
 ** In addition, any earlier program-order loads and stores must occur before the call to Volatile.Write.
 **/

/** 
 ** The Volatile.Read method forces the value in location to be read from at the point of the call. 
 ** In addition, any later program-order loads and stores must occur after the call to Volatile.Read.
 **/

internal sealed class ThreadsSharingData 
{
    private Int32 m_flag  = 0;
    private Int32 m_value = 0;
    
    public void Thread1() {  // This method is executed by one thread        
        m_value = 5;         // Note: 5 must be written to m_value before 1 is written to m_flag
        Volatile.Write(ref m_flag, 1);
    }
    
    public void Thread2() {                  // This method is executed by another thread       
        if (Volatile.Read(ref m_flag) == 1)  // Note: m_value must be read after m_flag is read
            Console.WriteLine(m_value);
    }
}


internal sealed class ThreadsSharingData {
   private volatile Int32 m_flag = 0;
   private          Int32 m_value = 0;
   
   public void Thread1() { // This method is executed by one thread      
      m_value = 5;         // Note: 5 must be written to m_value before 1 is written to m_flag
      m_flag = 1;
   }
   
   public void Thread2() { // This method is executed by another thread      
      if (m_flag == 1)     // Note: m_value must be read after m_flag is read
         Console.WriteLine(m_value);
   }
}