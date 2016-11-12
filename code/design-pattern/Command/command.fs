type CommandType = 
    | Deposit
    | Withdraw

type TCommand = 
    | Command of CommandType * int

let CommandPatternSample2() = 
    let result     = ref 7
    let deposit  x = result := !result + x
    let withdraw x = result := !result - x

    let Do = fun (cmd:TCommand) ->
        match cmd with 
        | Command(CommandType.Deposit, n) -> deposit n
        | Command(CommandType.Withdraw,n) -> withdraw n

    let Undo = fun (cmd:TCommand) ->
        match cmd with 
        | Command(CommandType.Deposit, n) -> withdraw n
        | Command(CommandType.Withdraw,n) -> deposit n

    printfn "current balance %d" !result

    let depositCmd = Command(Deposit, 3)

    Do depositCmd

    printfn "after deposit: %d" !result

    Undo depositCmd

    printfn "after undo: %d" !result
