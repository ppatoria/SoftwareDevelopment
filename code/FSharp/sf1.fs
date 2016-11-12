namespace FSUtils
 open System
open System.Collections.Concurrent
open System.IO
open System.Management.Automation
open System.Text
open System.Text.RegularExpressions
open System.Threading.Tasks
// holds info about lines of files matching the provided pattern
type LineMatch(filePath : string,
               currentPath : string,
               lineNumber : int,
               line : string,
               subStr : string,
               mo : Match option) = 

    member val Path = filePath
    member val RelativePath = filePath.Remove(0, currentPath.Length + 1)
    member val LineNumber = lineNumber
    member val Line = line
    member val Match = subStr

    // .[] access to match groups
    member this.Item 
        with get(i : int) =
            match mo with
            | Some(m) when m.Groups.[i].Success -> m.Groups.[i].Value
            | _ -> null

    member this.Item
        with get(i : string) = 
            match mo with
            | Some(m) when m.Groups.[i].Success -> m.Groups.[i].Value
            | _ -> null
 /// Class for doing regex searches of files on disk.
type FileSearcher(pattern : string, 
                  startingDirectory : string,
                  includePatterns : string[],
                  recurse : bool,
                  caseSensitive : bool,
                  simpleMatch : bool,
                  encoding : Encoding) =

    /// Function used to match individual lines of text
    let doMatch =
        match (simpleMatch, caseSensitive) with
        // full regex match, the slowest option
        | (false, _) ->
            let r = Regex(pattern, RegexOptions.Compiled |||
                     if caseSensitive then RegexOptions.None else RegexOptions.IgnoreCase)
            fun line ->
                match r.Match(line) with
                | m when m.Success -> Some(m.Value, Some(m))
                | _ -> None
        // case-sensitive match with String.Contains, the fastest option
        | (true, true) ->
            fun line ->
                match line.Contains(pattern) with
                | true -> Some(pattern, None)
                | false -> None
        // case-insensitive match with String.IndexOf, the second fastest opton
        | (true, false) ->
            fun line ->
                match line.IndexOf(pattern, StringComparison.OrdinalIgnoreCase) with
                | i when i >= 0 -> Some(line.Substring(i, pattern.Length), None)
                | _ -> None

    /// Returns all files in the specified directory matching
    ///    one or more of the wildcards in "includePatterns."
    let GetIncludedFiles dir = 
        includePatterns |> Seq.collect (fun p -> Directory.EnumerateFiles(dir, p))
    
    /// Pattern which matches a directory path with either
    ///   Contents(<files in the directory>, <directories in the directory>)
    ///   AccessDenied if unable to obtain directory contents
    let (|Contents|AccessDenied|) dir = 
            try
                Contents (GetIncludedFiles dir, 
                    if recurse then Directory.EnumerateDirectories(dir)
                    else Seq.empty
                )
            with | :? UnauthorizedAccessException -> AccessDenied
   
    /// Enumerates all accessible files in or under the specified directory.
    let rec GetFiles dir = 
        seq {
            match dir with
                | Contents(files, directories) ->
                    yield! files
                    yield! directories
                            |> Seq.collect GetFiles
                | AccessDenied -> ()            
        }

    /// Scans the specified file for lines matching the specified pattern and
    ///    inserts them into the blocking collection.
    let CollectLineMatches (collection : BlockingCollection<LineMatch>) file  =
        try
            File.ReadAllLines(file, encoding)
            |> Array.iteri (fun i line ->           
                match doMatch line with
                    | Some(str, mtch) ->
                        collection.Add(
                         LineMatch(file, startingDirectory, i + 1, line, str, mtch))
                    | None -> ()
              )
        with | :? IOException -> () // if we have issues accessing the file, just ignore
    
    /// Initiates the search for matching file content,
    ///   returning an enumerable of matching lines.
    /// Note that the search is executed in parallel and
    ///   thus the order of results is not guaranteed.
    member this.Search () =
        let bc = new BlockingCollection<LineMatch>()

        async {
            let tasks = 
                GetFiles startingDirectory
                |> Seq.map (fun file -> 
                    Task.Factory.StartNew(fun () -> CollectLineMatches bc file) )
                |> Seq.toArray
            
            if tasks.Length = 0 then
                bc.CompleteAdding()
            else
                Task.Factory.ContinueWhenAll(tasks, fun _ -> bc.CompleteAdding())
                |> ignore
        } |> Async.Start   
        
        bc.GetConsumingEnumerable()
