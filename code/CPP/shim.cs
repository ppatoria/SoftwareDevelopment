using System;
using System.Reflection;
using System.Threading;

class Shim
{
    static int Start(string args)
    {
        // The input arrives in a single string. Split it up.
        string[] aargs = args.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        string[] realargs = new string[aargs.Length - 1];
        Array.Copy(aargs, 1, realargs, 0, realargs.Length);

        // Now, execute the program in its own thread.
        AppDomain a = AppDomain.CurrentDomain;
        int exitCode = -1;
        Thread mainThread = new Thread(delegate() {
            exitCode = a.ExecuteAssembly(aargs[0], a.Evidence, realargs);
        });
        mainThread.Start();
        mainThread.Join();

        return exitCode;
    }

    static int Main(string[] args)
    {
        return Start(args[0]);
    }
}