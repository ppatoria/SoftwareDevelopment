using System;
using System.Collections;

namespace MSPress.CSharpCoreRef.ColorStack
{
	class StackApp
	{
		static void Main(string[] args)
		{
            Stack colorStack = new Stack();

            colorStack.Push("Red");
            colorStack.Push("Green");
            colorStack.Push("Blue");
            colorStack.Push("Yellow");
            colorStack.Push("Orange");

            Console.WriteLine("Contents of stack...");
            foreach(string color in colorStack)
            {
                Console.WriteLine(color);
            }

            while(colorStack.Count > 0)
            {
                string color = (string)colorStack.Pop();
                Console.WriteLine("Popping {0}", color);
            }
            Console.WriteLine("Done");
        }
	}
}
