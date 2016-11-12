using System;
using System.IO;

namespace MSPress.CSharpCoreRef.DirList
{
    /// <summary>
    /// Demonstrates a do-while loop and other flow-control
    /// techniques.
    /// </summary>
	class DirListApp
	{
		static void Main(string[] args)
		{
            string directoryPath;
            do
            {
                Console.WriteLine("Enter directory path, or <return> to quit.");
                directoryPath = Console.ReadLine();
                if(directoryPath.Length != 0)
                {
                    // Get a DirectoryInformation array for the
                    // specified path.
                    DirectoryInfo info = new DirectoryInfo(directoryPath);
                    DisplayDirectoryInfo(info);
                }
            }while(directoryPath.Length > 0);
		}

		static void DisplayDirectoryInfo(DirectoryInfo info)
		{
			try
			{
				DirectoryInfo[] directories = info.GetDirectories();
				foreach(DirectoryInfo directory in directories)
				{
					DisplayDirectoryInfo(directory);
				}
				FileInfo[] files = info.GetFiles();
				foreach(FileInfo file in files)
				{
					Console.WriteLine(file);
				}
			}
			catch(DirectoryNotFoundException)
			{
				Console.WriteLine("Could not find the directory.");
			}
			catch(Exception exc)
			{
				Console.WriteLine(exc);
			}
		}
	}
}
