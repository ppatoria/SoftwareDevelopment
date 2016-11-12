namespace FSUtils

open System.Management.Automation
open System.Text
open System.Text.RegularExpressions

/// Grep-like cmdlet Search-File
[<Cmdlet("Search", "File")>]
type SearchFileCmdlet() =
    inherit PSCmdlet()

    /// Regex pattern used in the search.
    [<Parameter(Mandatory = true, Position = 0)>]
    [<ValidateNotNullOrEmpty>]
    member val Pattern : string = null with get, set
    
    /// Array of filename wildcards.
    [<Parameter(Position = 1)>]
    [<ValidateNotNull>]
    member val Include = [|"*"|] with get,set
    
    /// Whether or not to recurse from the current directory.
    [<Parameter>]
    member val Recurse : SwitchParameter = SwitchParameter(false) with get, set

    /// Endcoding to use when reading the files.
    [<Parameter>]
    member val Encoding = Encoding.ASCII with get, set
    
    /// Toggle for case-sensitive search.
    [<Parameter>]
    member val CaseSensitive : SwitchParameter = SwitchParameter(false) with get, set

    /// Do not use regex, just do a verbatim string search.
    [<Parameter>]
    member val SimpleMatch : SwitchParameter = SwitchParameter(false) with get, set
    
    /// Called once per object coming from the pipeline.
    override this.ProcessRecord() =
        // check if simple match is possible, even if not specified explicitly
        let simple = this.SimpleMatch.IsPresent ||
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
