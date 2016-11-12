/*
 * Created by SharpDevelop.
 * User: Pralay
 * Date: 27-06-2010
 * Time: 12:40
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Runtime.Caching;
using System.Collections;
using System.Collections.Generic;
using System.IO;
namespace In_Mem_Cache
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			
			// TODO: Implement Functionality Here
			btnGet_Click();
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		
		
		private static void btnGet_Click()
		{
			ObjectCache cache = MemoryCache.Default;
			string fileContents = cache["filecontents"] as string;

			if (fileContents == null)
			{
				CacheItemPolicy policy = new CacheItemPolicy();
				
				List<string> filePaths = new List<string>();
				filePaths.Add("c:\\cache\\example.txt");

				policy.ChangeMonitors.Add(new
				                          HostFileChangeMonitor(filePaths));

				// Fetch the file contents.
				fileContents =
					File.ReadAllText("c:\\cache\\example.txt");
				
				cache.Set("filecontents", fileContents, policy);
			}

			//Label1.Text = fileContents;
		}
	}
}