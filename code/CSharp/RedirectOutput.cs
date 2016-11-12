using System;
using System.IO;

public class InsertTabs {
    
    public static void Main() {
        try {
		   StreamReader sr = new StreamReader(Console.OpenStandardInput);
           string line = Console.ReadLine();
           StreamWriter standardOutput = new StreamWriter(Console.OpenStandardOutput());
           standardOutput.AutoFlush = true;
           Console.SetOut(standardOutput);
           Console.WriteLine("line");
           Console.WriteLine("Test Over"); 
           standardOutput.Close();
           sr.Close();           
        }
        catch(IOException e) {
            Console.WriteLine(e.ToString());            
        }        
    }
}
