using System;

namespace MSPress.CSharpCoreRef.GcDemo
{
    class GcDemoApp
    {
        static void Main(string[] args)
        {
            using(ResourceConnector rc = new ResourceConnector())
            {
                for(int generation = 0; generation <= GC.MaxGeneration; ++generation)
                {
                    if(args.Length > 0 && args[0] == "wait")
                        rc.CollectAndAudit(generation, true);
                    else
                        rc.CollectAndAudit(generation, false);
                }
                rc.UseResource();
            }
        }
    }
}
