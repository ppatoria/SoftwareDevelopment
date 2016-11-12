let string_array = [|"ABC";"XYZ"|]

// let count_if functor1 =
//     string_array
//     |> Array.filter(functor1)
//     |> Array.length

let count_if functor1 (array:string[]) =
    array
    |> Array.filter(functor1)
    |> Array.length
    
string_array
|> count_if (fun x -> x.Length < 5)
|> printfn "%d"

printfn "%d" <| count_if (fun x -> x.Length < 5)  string_array
