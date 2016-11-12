open System
open System.IO

let oldOutput = Console.Out
let stringOutput = new StringWriter() 
Console.SetOut(stringOutput) // set console output to StringWriter
 
Console.Write("some string")
Console.Out.Flush() 
let a_string = stringOutput.GetStringBuilder().ToString()

Console.SetOut(oldOutput) 
Console.WriteLine(a_string);
