using System;
using System.IO;
using System.Collections.Generic;

class Test
{
    public static void Main(string[] args){
	Console.WriteLine(Size("c:\\temp"));
    }

    public static long Size(string directory){
	long size = 0;		
	foreach(string file in Directory.GetFiles(directory, "*.*",  SearchOption.AllDirectories))	                               
	    size += (new FileInfo(file).Length);			
	return size;
    }

    public static void Size(string directory,ref long size){
	foreach(string file in Directory.GetFiles(directory, "*.*",  SearchOption.AllDirectories))	                               
	    size += (new FileInfo(file).Length);	
    }


}