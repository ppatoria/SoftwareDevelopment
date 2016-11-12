using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

public static class Program {
    public static void Main() {
        ValueTypePerfTest();
        ReferenceTypePerfTest();
    }

    private static void ValueTypePerfTest() {
        
        const Int32 count = 100000000;
        
        using (new OperationTimer("List<Int32>")) {

            List<Int32> l = new List<Int32>();

            for (Int32 n  = 0; n < count; n++) {
                l.Add(n);                                  // No boxing
                Int32 x   = l[n];                          // No unboxing
            }
        
            l = null;                                      // Make sure this gets garbage collected
        }

        using (new OperationTimer("ArrayList of Int32")) {
            
            ArrayList a = new ArrayList();
            
            for (Int32 n = 0; n < count; n++) {
                a.Add(n);                                  // Boxing
                Int32 x = (Int32) a[n];                    // Unboxing
            }
            
            a = null;                                      // Make sure this gets garbage collected
        }
    }

    private static void ReferenceTypePerfTest() {
        const Int32 count = 100000000;

        using (new OperationTimer("List<String>")) {
            
            List<String> l = new List<String>();
            
            for (Int32 n = 0; n < count; n++) {
                l.Add("X");                                // Reference copy
                String x = l[n];                           // Reference copy
            }
            
            l = null;                                      // Make sure this gets garbage collected
        }

        using (new OperationTimer("ArrayList of String")) {
            
            ArrayList a = new ArrayList();
            
            for (Int32 n = 0; n < count; n++) {
                a.Add("X");                                // Reference copy
                String x = (String) a[n];                  // Cast check & reference copy
            }
            
            a = null;                                      // Make sure this gets garbage collected
        }
    }
}

// This class is useful for doing operation performance timing
internal sealed class OperationTimer : IDisposable {
    private Stopwatch m_stopwatch;
    private String    m_text;
    private Int32     m_collectionCount;

    public OperationTimer(String text) {
        PrepareForOperation();
        m_text            = text;
        m_collectionCount = GC.CollectionCount(0);        
        m_stopwatch       = Stopwatch.StartNew();          //last statement to keep timing accurate as possible
    }

    public void Dispose() {
        Console.WriteLine("{0} (GCs={1,3}) {2}", (m_stopwatch.Elapsed),
                          GC.CollectionCount(0) - m_collectionCount, m_text);
    }

    private static void PrepareForOperation() {
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
    }
}