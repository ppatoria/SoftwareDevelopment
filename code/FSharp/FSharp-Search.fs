namespace FSUtils

open System
open System.Collections.Concurrent
open System.IO
open System.Management.Automation
open System.Text
open System.Text.RegularExpressions
open System.Threading.Tasks

// holds info about lines of files matching the provided pattern
type LineMatch(filePath    : string,
               currentPath : string,
               lineNumber  : int,
               line        : string,
               subStr      : string,
               mo          : Match option) = 

    member val Path         = filePath
    member val RelativePath = filePath.Remove(0, currentPath.Length + 1)
    member val LineNumber   = lineNumber
    member val Line         = line
    member val Match        = subStr

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
type FileSearcher(pattern           : string, 
                  startingDirectory : string,
                  includePatterns   : string[],
                  recurse           : bool,
                  caseSensitive     : bool,
                  simpleMatch       : bool,
                  encoding          : Encoding) =    
    let doMatch =                                                                    /// Function used to match individual lines of text
        match (simpleMatch, caseSensitive) with                                      // full regex match, the slowest option
        | (false, _) ->
            let r = Regex(pattern, RegexOptions.Compiled |||
                    if caseSensitive then RegexOptions.None
                    else RegexOptions.IgnoreCase)
            fun line ->
                match r.Match(line) with
                | m when m.Success -> Some(m.Value, Some(m))
                | _ -> None        
        | (true, true) ->                                                            //case-sensitive match with String.Contains, the fastest option
            fun line ->
                match line.Contains(pattern) with
                | true -> Some(pattern, None)
                | false -> None        
        | (true, false) ->                                                           //case-insensitive match with String.IndexOf, the second fastest opton
            fun line ->
                match line.IndexOf(pattern, StringComparison.OrdinalIgnoreCase) with
                | i when i >= 0 -> Some(line.Substring(i, pattern.Length), None)
                | _ -> None
                                                                                     
                                                                                     
    let GetIncludedFiles dir =                                                       /// Returns all files in the specified directory matching
        includePatterns |> Seq.collect (fun p -> Directory.EnumerateFiles(dir, p))   ///    one or more of the wildcards in "includePatterns."
    
        let (|Contents|AccessDenied|) dir =                                          ///Pattern which matches a directory path with either
            try                                                                      ///Contents(<files in the directory>, <directories in the directory>)  
                Contents (GetIncludedFiles dir,                                      ///   AccessDenied if unable to obtain directory contents 
                    if recurse then Directory.EnumerateDirectories(dir)
                    else Seq.empty
                )
            with | :? UnauthorizedAccessException -> AccessDenied   
    
    let rec GetFiles dir =                                                           ///Enumerates all accessible files in or under the specified directory.
        seq {
            match dir with
                | Contents(files, directories) ->
                    yield! files
                    yield! directories
                            |> Seq.collect GetFiles
                | AccessDenied -> ()            
        }



    let CollectLineMatches (collection : BlockingCollection<LineMatch>) file  =    /// Scans the specified file for lines matching the specified pattern and
        try    ///    inserts them into the blocking collection.
            File.ReadAllLines(file, encoding)
            |> Array.iteri (fun i line ->           
                match doMatch line with
                    | Some(str, mtch) ->
                        collection.Add(
                         LineMatch(file, startingDirectory, i + 1, line, str, mtch))
                    | None -> ()
              )
        with | :? IOException -> ()                                                // if we have issues accessing the file, just ignore
        
    member this.Search () =                                                        /// Initiates the search for matching file content,
        let bc = new BlockingCollection<LineMatch>()                               ///   returning an enumerable of matching lines.
        async {                                                                    /// Note that the search is executed in parallel and
            let tasks =                                                            ///   thus the order of results is not guaranteed.
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


[<Cmdlet("Search", "File")>]                                                       /// Grep-like cmdlet Search-File
type SearchFileCmdlet() =
    inherit PSCmdlet()


    [<Parameter(Mandatory = true, Position = 0)>]s
    [<ValidateNotNullOrEmpty>]                                                     /// Regex pattern used in the search.
    member val Pattern : string = null with get, set
    

    [<Parameter(Position = 1)>]
    [<ValidateNotNull>]                                                            /// Array of filename wildcards.
    member val Include = [|"*"|] with get,set
    
    [<Parameter>]                                                                  /// Whether or not to recurse from the current directory.
    member val Recurse : SwitchParameter = SwitchParameter(false) with get, set

    [<Parameter>]                                                                  /// Endcoding to use when reading the files.
    member val Encoding = Encoding.ASCII with get, set
    
    [<Parameter>]                                                                  /// Toggle for case-sensitive search.
    member val CaseSensitive : SwitchParameter = SwitchParameter(false) with get, set

    [<Parameter>]                                                                  /// Do not use regex, just do a verbatim string search.
    member val SimpleMatch : SwitchParameter = SwitchParameter(false) with get, set

    override this.ProcessRecord() =                                                /// Called once per object coming from the pipeline.
        let simple = this.SimpleMatch.IsPresent ||                                 // check if simple match is possible, even if not specified explicitly
                     (fun s -> s = Regex.Escape(s)) (Regex.Replace(this.Pattern, "\s", ""))
                     
        let searcher = FileSearcher(this.Pattern,
                                    this.SessionState.Path.CurrentFileSystemLocation.Path,
                                    this.Include,
                                    this.Recurse.IsPresent,
                                    this.CaseSensitive.IsPresent,
                                    simple,
                                    this.Encoding)
        searcher.Search()
        |> Seq.iter(fun item -> this.WriteObject(item))
