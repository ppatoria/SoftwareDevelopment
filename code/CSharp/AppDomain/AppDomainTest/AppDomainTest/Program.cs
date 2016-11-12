using System;
using System.Threading;
using System.Reflection;
using System.Runtime.Remoting;
using ApplomainMarshallableDll;
using System.Diagnostics;
namespace AppDomainTest
{

    public class Worker : MarshalByRefObject
    {
        public void PrintDomain()
        {
            Console.WriteLine("Object is executing in AppDomain \"{0}\"",
                AppDomain.CurrentDomain.FriendlyName);
        }
    }

    class Example
    {
        public static void Main()
        {
            // Create an ordinary instance in the current AppDomain
            //Worker localWorker = new Worker();
            //localWorker.PrintDomain();

            // Create a new application domain, create an instance
            // of Worker in the application domain, and execute code
            // there.
            AppDomain ad = AppDomain.CreateDomain("New domain");
            try {
                //Assembly asm = Assembly.Load("ApplomainMarshallableDll");

                //ApplomainMarshallableDll.MarshalByRefType mbrt1 = (ApplomainMarshallableDll.MarshalByRefType)
                //ad.CreateInstanceAndUnwrap(Assembly.GetExecutingAssembly().FullName,
                //    "MarshalByRefType");
                ApplomainMarshallableDll.MarshalByRefType mbrt1 = (ApplomainMarshallableDll.MarshalByRefType)
                ad.CreateInstanceFrom(Assembly.GetExecutingAssembly().FullName,
                    "MarshalByRefType");
                mbrt1.SomeMethod();

                ad.CreateComInstanceFrom("", "").Unwrap();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                Debug.WriteLine(ex.ToString());
            }
        }
    }

    /* This code produces output similar to the following:

    Object is executing in AppDomain "source.exe"
    Object is executing in AppDomain "New domain"
     */

    //class Test
    //{

    //    public static void Main()
    //    {
    //        Marshalling();
    //    }
    //    private static void Marshalling()
    //    {

    //        AppDomain thisDomain = AppDomain.CurrentDomain;
    //        ApplomainMarshallableDll.MarshalByRefType mbrt1 = null;
    //        try {
    //            mbrt1 = (ApplomainMarshallableDll.MarshalByRefType)
    //            thisDomain.CreateInstanceAndUnwrap("ApplomainMarshallableDll", "MarshalByRefType");
    //        }
    //        catch (Exception ex) {
    //            Console.WriteLine(ex.ToString());
    //        }

    //        // Get a reference to the AppDomain that that calling thread is executing in
    //        AppDomain adCallingThreadDomain = Thread.GetDomain();
    //        // Every AppDomain is assigned a friendly string name (helpful for debugging)
    //        // Get this AppDomain’s friendly string name and display it
    //        String callingDomainName = adCallingThreadDomain.FriendlyName;
    //        Console.WriteLine("Default AppDomain’s friendly name={0}", callingDomainName);
    //        // Get & display the assembly in our AppDomain that contains the ‘Main’ method
    //        String exeAssembly = Assembly.GetEntryAssembly().FullName;
    //        Console.WriteLine("Main assembly={0}", exeAssembly);
    //        // Define a local variable that can refer to an AppDomain
    //        AppDomain ad2 = null;
    //        // *** DEMO 1: Cross-AppDomain Communication using Marshal-by-Reference ***
    //        Console.WriteLine("{0}Demo #1", Environment.NewLine);
    //        // Create new AppDomain (security & configuration match current AppDomain)
    //        ad2 = AppDomain.CreateDomain("AD #2", null, null);
    //        MarshalByRefType mbrt = null;
    //        //598 Part IV Core Facilities
    //        // Load our assembly into the new AppDomain, construct an object, marshal
    //        // it back to our AD (we really get a reference to a proxy)
    //        MarshalByRefType test = new MarshalByRefType();
    //        test.SomeMethod();
    //        try {
    //            mbrt = (MarshalByRefType)
    //            ad2.CreateInstanceAndUnwrap(exeAssembly, "MarshalByRefType");
    //        }
    //        catch (Exception ex) {
    //            Console.WriteLine(ex.ToString());
    //        }
    //        Console.WriteLine("Type={0}", mbrt.GetType()); // The CLR lies about the type
    //        // Prove that we got a reference to a proxy object
    //        Console.WriteLine("Is proxy={0}", RemotingServices.IsTransparentProxy(mbrt));
    //        // This looks like we’re calling a method on MarshalByRefType but, we’re not.
    //        // We’re calling a method on the proxy type. The proxy transitions the thread
    //        // to the AppDomain owning the object and calls this method on the real object.
    //        mbrt.SomeMethod();
    //        // Unload the new AppDomain
    //        AppDomain.Unload(ad2);
    //        // mbrt refers to a valid proxy object; the proxy object refers to an invalid AppDomain
    //        try {
    //            // We’re calling a method on the proxy type. The AD is invalid, exception is thrown
    //            mbrt.SomeMethod();
    //            Console.WriteLine("Successful call.");
    //        }
    //        catch (AppDomainUnloadedException) {
    //            Console.WriteLine("Failed call.");
    //        }
    //        // *** DEMO 2: Cross-AppDomain Communication using Marshal-by-Value ***
    //        Console.WriteLine("{0}Demo #2", Environment.NewLine);
    //        // Create new AppDomain (security & configuration match current AppDomain)
    //        ad2 = AppDomain.CreateDomain("AD #2", null, null);
    //        // Load our assembly into the new AppDomain, construct an object, marshal
    //        // it back to our AD (we really get a reference to a proxy)
    //        mbrt = (MarshalByRefType)
    //        ad2.CreateInstanceAndUnwrap(exeAssembly, "MarshalByRefType");
    //        // The object’s method returns a COPY of the returned object;
    //        // the object is marshaled by value (not be reference).
    //        MarshalByValType mbvt = mbrt.MethodWithReturn();
    //        // Prove that we did NOT get a reference to a proxy object
    //        Console.WriteLine("Is proxy={0}", RemotingServices.IsTransparentProxy(mbvt));
    //        // This looks like we’re calling a method on MarshalByValType and we are.
    //        // Unload the new AppDomain
    //        AppDomain.Unload(ad2);
    //        // mbvt refers to valid object; unloading the AppDomain has no impact.
    //        try {
    //            // We’re calling a method on an object; no exception is thrown
    //            Console.WriteLine("Returned object created " + mbvt.ToString());
    //            Console.WriteLine("Successful call.");
    //        }
    //        catch (AppDomainUnloadedException) {
    //            Console.WriteLine("Returned object created " + mbvt.ToString());
    //            Console.WriteLine("Failed call.");
    //        }
    //        // DEMO 3: Cross-AppDomain Communication using non-marshalable type ***
    //        Console.WriteLine("{0}Demo #3", Environment.NewLine);
    //        // Create new AppDomain (security & configuration match current AppDomain)
    //        ad2 = AppDomain.CreateDomain("AD #2", null, null);
    //        // Load our assembly into the new AppDomain, construct an object, marshal
    //        // it back to our AD (we really get a reference to a proxy)
    //        mbrt = (MarshalByRefType)
    //        ad2.CreateInstanceAndUnwrap(exeAssembly, "MarshalByRefType");
    //        // The object’s method returns an non-marshalable object; exception
    //        NonMarshalableType nmt = mbrt.MethodArgAndReturn(callingDomainName);
    //        // We won’t get here...
    //    }
    //}
    // Instances can be marshaled-by-reference across AppDomain boundaries
    public sealed class MarshalByRefType : MarshalByRefObject
    {
        public MarshalByRefType()
        {
            Console.WriteLine("{0} ctor running in {1}",
            this.GetType().ToString(), Thread.GetDomain().FriendlyName);
        }
        public void SomeMethod()
        {
            Console.WriteLine("Executing in " + Thread.GetDomain().FriendlyName);
        }
        public MarshalByValType MethodWithReturn()
        {
            Console.WriteLine("Executing in " + Thread.GetDomain().FriendlyName);
            MarshalByValType t = new MarshalByValType();
            return t;
        }
        public NonMarshalableType MethodArgAndReturn(String callingDomainName)
        {
            // NOTE: callingDomainName is [Serializable]
            Console.WriteLine("Calling from ‘{0}’ to ‘{1}’.",
            callingDomainName, Thread.GetDomain().FriendlyName);
            NonMarshalableType t = new NonMarshalableType();
            return t;
        }
    }
    // Instances can be marshaled-by-value across AppDomain boundaries
    [Serializable]
    //600 Part IV Core Facilities
    public sealed class MarshalByValType : Object
    {
        private DateTime m_creationTime = DateTime.Now; // NOTE: DateTime is [Serializable]
        public MarshalByValType()
        {
            Console.WriteLine("{0} ctor running in {1}, Created on {2:D}",
            this.GetType().ToString(),
            Thread.GetDomain().FriendlyName,
            m_creationTime);
        }
        public override String ToString()
        {
            return m_creationTime.ToLongDateString();
        }
    }
    // Instances cannot be marshaled across AppDomain boundaries
    // [Serializable]
    public sealed class NonMarshalableType : Object
    {
        public NonMarshalableType()
        {
            Console.WriteLine("Executing in " + Thread.GetDomain().FriendlyName);
        }
    }
}