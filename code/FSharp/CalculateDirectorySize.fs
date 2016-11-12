open System.IO

//*********************************************************************//
                                                                          
let printd msg value =
    printfn "%s: %d" msg,value

//*********************************************************************//
                                                                         
let calculate_directory_size directory =
    Directory.GetFiles (directory)
    |> Array.map       (fun file     -> new FileInfo(file))           
    |> Array.map       (fun fileInfo -> fileInfo.Length)
    |> Array.sum
    
//*********************************************************************//
                                                                          
printfn "%d" <| calculate_directory_size "c:\\temp"

//*********************************************************************//
                                                                          
let calculate_directory_size_linq path =
    let files =
        for file in Directory.GetFiles(path)
        select new FileInfo
        files |> Array.sum
    
//*********************************************************************//
                                                                          
calculate_directory_size "c:\\temp"
|> printd "Directory size"

//*********************************************************************//
                                                                          
#r "System.IO"
open System.IO

//*********************************************************************//
                                                                          
let SearchOption isRecursive =
    if isRecursive then
        SearchOption.AllDirectories
    else
        SearchOption.TopDirectoryOnly
//*********************************************************************//

let list_files  path pattern isRecursive =           
    Directory.GetFiles(path, pattern, SearchOption isRecursive)

//*********************************************************************//
                                                                          
list_files "c:\\temp"

//*********************************************************************//
// let CalculateDirectorySize =
//     let getFiles directory =
//         Directory.GetFiles(directory, "*.*", SearchOption.AllDirectories)
//     getFiles    
//     >> Array.map(fun file -> new FileInfo(file))                      
//     >> Array.map (fun info -> info.Length)
//     >> Array.sum
// let result = CalculateDirectorySize "c:\\temp"
// printfn "%d" result
    
