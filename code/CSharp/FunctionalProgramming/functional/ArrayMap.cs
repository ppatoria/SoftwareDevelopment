using System;
using System.Linq;

class ArrayMap
{

	public static void Main()
	{
		var words = new[] { "a", "b", "c", "d" };
		var selectedWords = words.Select(word => word + "!").ToArray();
		foreach(var word in selectedWords) Console.WriteLine(word);	
	}
}
