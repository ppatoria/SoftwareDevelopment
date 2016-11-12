using System;
using System.IO;

namespace Interactive
{
	public class Interactive
	{
		public static void Main(){
			while(true)
			{				
				string line = Console.ReadLine();
				Console.WriteLine(line);
			}
		}	
	}
}