using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

public class program
{
    public static void Main(){
        Int64 size = DirectoryBytes(@"c:\temp", "*.*", SearchOption.AllDirectories);
        Console.WriteLine(size);
    }

    private static Int64 DirectoryBytes(String path, String searchPattern,
                                        SearchOption searchOption) {
        var files = Directory.EnumerateFiles(path, searchPattern, searchOption);
        Int64 masterTotal = 0;

        ParallelLoopResult result = Parallel.ForEach<String, Int64>(
            /* Container */
            files,

            /* Initialize accumulator*/
            () => { // localInit: Invoked once per task at start
                // Initialize that this task has seen 0 bytes
                return 0;   // Set taskLocalTotal initial value to 0
            },

            /* process body */
            (file, loopState, index, taskLocalTotal) => { // body: Invoked once per work item
                // Get this file's size and add it to this task's running total
                Int64 fileLength = 0;
                FileStream fs = null;
                try {
                    fs = File.OpenRead(file);
                    fileLength = fs.Length;
                }
                catch (IOException) { /* Ignore any files we can't access */ }
                finally { if (fs != null) fs.Dispose(); }
                return taskLocalTotal + fileLength;
            },
            
            /* Accumulate*/
            taskLocalTotal => { // localFinally: Invoked once per task at end
                // Atomically add this task's total to the "master" total
                Interlocked.Add(ref masterTotal, taskLocalTotal);
            });

        return masterTotal;
    }
}