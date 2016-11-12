open System
open System.IO

let calculate_directory_size directory =
    Directory.GetFiles (directory)
    |> Array.map       (fun file     -> new FileInfo(file))                      
    |> Array.map       (fun fileInfo -> fileInfo.Length)
    |> Array.sum


let calculate_directory_size_1 directory =
    Directory.GetFiles (directory)
    |> Array.map       (fun file     -> (new FileInfo(file)).Length)                      
    |> Array.sum

let calculate_directory_size_2 directory =
    Directory.GetFiles (directory)
    |> Array.map       (fun file     -> new FileInfo(file))                      
    |> Array.sum       (fun fileInfo -> fileInfo.Length)
    
printfn "%d" <| calculate_directory_size   "c:\\temp"
printfn "%d" <| calculate_directory_size_1 "c:\\temp"
printfn "%d" <| calculate_directory_size_2 "c:\\temp"
