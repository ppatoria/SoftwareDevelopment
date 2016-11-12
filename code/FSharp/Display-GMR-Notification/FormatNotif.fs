open System
open System.Data

[<EntryPoint>]
let main(args : string[])=            
    printfn "%s" args.[0]
    printfn "%s" args.[1]    

    let notifTable = new DataTable()    
    let subscription_list = "Topic,UserName" + args.[0]
    //printfn "%s" fields
    let fields = subscription_list.Split(',')
    for field in fields do
        notifTable.Columns.Add(field, typeof<string>) |> ignore
//        printfn "%s" field
    

    printfn "Enter notification"
    let notif  = Console.ReadLine()
    
    let values = notif.Split(args.[1].[0])

    // for value in values do
    //     let row = new notifTable.NewRow();
    //     row[i] = value
    //     i++
    //     //printfn "%s" value

    for i = 0 to values.Length do
        let row = notifTable.NewRow()
        let cname = notifTable.Columns[i]
        row[cname] = values[i]
    notifTable.Rows.Add(row)
    0
