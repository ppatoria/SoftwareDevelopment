using System;
using System.Windows.Forms;
namespace MSPress.CSharpCoreRef.DisplayKeys
{
    class DisplayKeysApp
    {
        [STAThread]
        static void Main(string[] args)
        {
            string [] keyNames = Enum.GetNames(typeof(Keys));
            foreach(string name in keyNames)
            {
                Console.WriteLine(name);
            }
        }
    }
}
