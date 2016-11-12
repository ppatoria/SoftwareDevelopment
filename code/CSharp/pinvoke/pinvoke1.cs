using System;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
class SystemTime
{
    public ushort Year;
    public ushort Month;
    public ushort DayOfWeek;
    public ushort Day;
    public ushort Hour;
    public ushort Minute;
    public ushort Second;    
    public ushort Milliseconds;
}

class Program
{
    [DllImport("kernel32.dll")]
    static extern void GetSystemTime (SystemTime t);
    static void Main()
        {
            SystemTime t = new SystemTime();
            GetSystemTime (t);
            Console.WriteLine (t.Year);
        }
}