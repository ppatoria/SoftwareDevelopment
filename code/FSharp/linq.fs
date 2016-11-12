open System;

type Customer ={
    Name        :string;
    UniqueID    :int;
    Weighting   :float;
    Preferences :int list
}

let c1 = {Name="Don"  ;  UniqueID=6; Weighting=6.2; Preferences=[1;2;4;8]     }
let c2 = {Name="Peter";  UniqueID=7; Weighting=4.2; Preferences=[10;20;30;40] }
let c3 = {Name="Freddy"; UniqueID=8; Weighting=9.2; Preferences=[11;12;14]    }
let c4 = {Name="Freddi"; UniqueID=9; Weighting=1.0; Preferences=[21;22;29;42] }
 
let customers = [c1;c2;c3;c4]

//**************************************************************************

let query_l customers=
    [ for cust in customers do
          if cust.Name.Length = 6 then
              yield (cust.Name,cust.UniqueID) ]
    
printfn "%A" <| query_l customers

//**************************************************************************

let query_f customers=
    customers
    |> List.filter ( fun cust -> cust.Name.Length = 6)
    |> List.map    ( fun cust -> cust.Name,cust.UniqueID)   

printfn "%A" <| query_f customers

//*************************************************************************  

let sum list =
    list
    |> List.reduce (fun acc i -> acc + i)
    
printfn "%d" <| sum [1; 2; 3; 4; 5]
    
//**************************************************************************

let listWords = [ "and"; "Rome"; "Bob"; "apple"; "zebra" ]

let isCapitalized1 (string1:string) = System.Char.IsUpper string1.[0]

let results1 = List.choose (fun elem ->
                            match elem with
                            | elem when isCapitalized1 elem -> Some(elem + "'s")
                            | _ -> None) listWords

printfn "%A" results1

//**************************************************************************

let isCapitalized (word:string) = System.Char.IsUpper word.[0]

let results = List.choose (fun e ->
                           match e with
                           | e when isCapitalized e -> Some(e + "'s")
                           | _ -> None) listWords

printfn "%A" results

//**************************************************************************

let isCapital (word:string) =  Char.IsUpper word.[0]     

let result = List.choose(fun word -> 
                         if isCapital word then Some(word + "'s")
                         else None) listWords
printfn "%A" result

//**************************************************************************

listWords
|> List.filter ( fun word -> isCapitalized word )
|> List.iter   ( fun word -> Some(word))
|> printf "%A"


//**************************************************************************




