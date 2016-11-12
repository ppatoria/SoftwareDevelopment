let square n = n * n

let rec loop n func  =
    if n > 0 then        
        printfn "n = %i" n
        let sqr = square n
        //printfn "square = %i" sqr
        fun n -> 
        loop (n-1 func)

let rec loop n  =
    let count = 0    
    if count < n then        
        printfn "= %i" count                 
        loop (count + 1)
