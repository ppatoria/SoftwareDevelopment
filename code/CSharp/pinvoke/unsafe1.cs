struct Test
{
    int x;
    unsafe static void Main()
        {
            Test test = new Test();
            Test* p   = &test;
            p->x      = 9;
            System.Console.WriteLine (test.x);
        }
}