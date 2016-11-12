open System.Windows.Forms
open System.IO
open System.Net

// let http (url:string) =
//     let req    = WebRequest.Create      (url)
//     let resp   = req.GetResponse        ()
//     let stream = resp.GetResponseStream ()
//     let reader = new StreamReader       (stream)
//     let html   = reader.ReadToEnd       ()
//     resp.Close()
//     html

let http (url:string) =

    let stream =
        WebRequest.Create(url).GetResponse().GetResponseStream ()
    let reader = new StreamReader       (stream)
    let html   = reader.ReadToEnd       ()
    //resp.Close()
    html
    
let fetch url =
     try Some (http url)
     with :? System.Net.WebException -> None
     
match (fetch "http://news.bbc.co.us") with
   | Some text -> printfn "text = %s" text
   | None      -> printfn "**** no web page found";;
