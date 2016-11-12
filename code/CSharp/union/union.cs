using System;
using System.Runtime.InteropServices;

[ StructLayout(LayoutKind.Explicit) ]
public struct UnionTest
{
    // Set the offsets to the same position so that both variables occupy
    // the same memory address which is essentially C++ union does.

    [ FieldOffset(0) ] public char                  chVal;
    [ FieldOffset(0) ] public System.Int16          intVal;
}     

class Class1
{
    [STAThread]
    static void Main(string[] args)
        {
            UnionTest u = new UnionTest();
            // Set via Int and get through Char
            u.intVal = 65;
            Console.WriteLine("chVal:{0}",u.chVal );
            // Set via Char and get through Int
            u.chVal = 'B';
            Console.WriteLine("intVal:{0}",u.intVal );
        }
}