using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Runtime.Remoting;

namespace ApplomainMarshallableDll
{
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
