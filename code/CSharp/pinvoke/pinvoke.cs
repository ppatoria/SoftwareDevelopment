using System;
using System.Text;
using System.Runtime.InteropServices;

class Test
{
    [DllImport("kernel32.dll")]
    //static extern int GetWindowsDirectory (StringBuilder sb, int maxChars);
    static extern int GetWindowsDirectory (char* out_directoryName, int maxChars);
    static void Main()
        {
            //StringBuilder s = new StringBuilder (256);
            string s = string.Empty;
            GetWindowsDirectory (s.ToChar(), 256);
            Console.WriteLine (s);
        }
}