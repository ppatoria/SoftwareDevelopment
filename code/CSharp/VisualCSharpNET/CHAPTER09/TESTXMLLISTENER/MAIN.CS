using System;
using System.IO;
using System.Diagnostics;
using MSPress.CSharpCoreRef.XmlListener;

namespace MSPress.CSharpCoreRef.TestXmlListener
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    class TestXmlListenerApp
    {
        static void Main(string[] args)
        {
            FileStream stream = new FileStream("TraceInfo.xml", 
                                               FileMode.Create);
            XmlStreamTraceListener xstl = new XmlStreamTraceListener(stream, 
                                                                     "XML application tracing");
            Trace.Listeners.Add(xstl); 

            GenerateAssertion();
            
            Trace.Flush();
            Trace.Close();
        }

        static void GenerateAssertion()
        {
            Trace.Assert(false);
        }
    }
}
