using System;
using System.Collections;
using System.IO;
using System.Linq;

class CalculateDirectorySize
{
    Action<object> println = Console.WriteLine;

/**************************************************************************/
    public static void 
    Main(string[] args) {	
        string path = "c:\\temp";

        print ("calculate_directory_size_cpp_style",          calculate_directory_size_cpp_style,          path);        
        print ("calculate_directory_size_csharp_style",       calculate_directory_size_csharp_style,       path);
        print ("calculate_directory_size_functional_1",       calculate_directory_size_functional_1,       path);
        print ("calculate_directory_size_functional_2",       calculate_directory_size_functional_2,       path);
        print ("calculate_directory_size_functional_3",       calculate_directory_size_functional_3,       path);
        print ("calculate_directory_size_functional_linq",    calculate_directory_size_functional_linq,    path);
        print ("calculate_directory_size_functional_linq_1",  calculate_directory_size_functional_linq_1,  path);
    }
/**************************************************************************/

    public static void
    print ( string            description, 
            Func<string,long> get_directory_size, 
            string            path ){        
    
        Console.WriteLine("{0}: {1}",description, get_directory_size(path));
    }

/**************************************************************************/
    public static long 
    calculate_directory_size_cpp_style    (string path) {       

        long sum = 0;		
        IEnumerator iter  =  Directory.GetFiles(path).GetEnumerator();
        while(iter.MoveNext()) {
            FileInfo file = new FileInfo(iter.Current as string);
            sum += file.Length;
        }
        return sum;	
    }
/**************************************************************************/
    public static long 
    calculate_directory_size_csharp_style    (string path)        {

        long sum = 0;		     
        foreach(var file in Directory.GetFiles(path))  
            sum += (new FileInfo(file)).Length;                        
        return sum;	
    }
/**************************************************************************/
    public static long 
    calculate_directory_size_functional_1    ( string path )        {		
        return		
            Directory
	    .GetFiles (path)
            .Select   (file     => new FileInfo(file))
            .Select   (fileInfo => fileInfo.Length)
            .Sum      ();			
    }    

/**************************************************************************/
    public static long 
    calculate_directory_size_functional_2    ( string path )        {		
        return		
            Directory
	    .GetFiles (path)
            .Select   (file     => new FileInfo(file))
            .Sum      (fileInfo => fileInfo.Length);            
    }    


/**************************************************************************/
    public static long 
    calculate_directory_size_functional_3    ( string path )        {		
        return		
            Directory
	    .GetFiles (path)
            .Sum      (file => new FileInfo(file).Length);            
    }  
  
/**************************************************************************/
    public static long 
    calculate_directory_size_functional_linq    ( string path )        {
 
	var fileSizes =
	    from file in Directory.GetFiles(path)            
	    select  (new FileInfo(file)).Length;
        return fileSizes.Sum();
    }
/**************************************************************************/
    public static long 
    calculate_directory_size_functional_linq_1   ( string path ) {
     
        var files =
            from file in Directory.GetFiles(path)            
            select  new FileInfo(file);
        return files.Sum(file => file.Length);
    }  
  
/**************************************************************************/
    public static long
        calcutable_Directorytoru_size_functional_linq_2(string path)
    {
        return
        
        Directory.GetFiles(path)
            .Select(file = > new FileInfo(file))
            .Sum(file_info => file_info.Length);
    }
}
