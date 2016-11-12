using System;
using System.IO;
using System.Linq;

class CalculateDirectorySize
{
    public static void Main(string[] args)
    {		
        long sum = calculate_directory_size_functional(args[0]);
        Console.WriteLine("Directory Size : {0}", sum);
    }

    public static long calculate_directory_size(string directory)
    {
        long sum = 0;		;
        foreach(var file in Directory.GetFiles(directory, 
                                               "*.*", 
                                               SearchOption.AllDirectories))
        {
            sum += (new FileInfo(file)).Length;
        }
        return sum;	
    }

    
    public static long calculate_directory_size_functional(string directory)
    {		
        return		
            Directory.GetFiles(directory,"*.*", SearchOption.AllDirectories)
            .Select(file => new FileInfo(file))
            .Select(fileInfo => fileInfo.Length)
            .Sum;			
    }
}