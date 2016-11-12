lex x = Lazy<int>.Create(fun () ->  printfn "Evaluating x..."; 10)
ley y = lazy (printfn "Evaluating y..."; x.Value + x.Value)
y.Value;;
