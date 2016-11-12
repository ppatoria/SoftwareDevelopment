open System.Windows.Forms
open System.IO
open System.Net


//Get the contents of the URL via a web request
let http (url: string) =
    let req    = System.Net.WebRequest.Create (url)
    let resp   = req.GetResponse              ()
    let stream = resp.GetResponseStream       ()
    let reader = new StreamReader             (stream)
    let html   = reader.ReadToEnd             ()
    resp.Close()
    html    
    

// let http (url: string) =
//     let stream =
//         System.Net.WebRequest.Create (url) |>
//         GetResponse |>
//         GetResponseStream 
//     // let html   =
//     //     new StreamReader(stream).ReadToEnd()
//     // resp.Close()
//     // html

let html =  http "http://news.bbc.co.uk"
printfn "%s" html


let textB = new RichTextBox (Dock = DockStyle.Fill,
                             Text = "Here is some initial text")

textB.Text <- html

let form = new Form (Visible = true ,
                     TopMost = true,
                     Text    = "Welcome to F#")

form.Controls.Add textB 



//printfn "%d" html.Lenght
//textB.Text <- http "http://news.bbc.co.uk" 
//textB.Text <- http "http://google.com" 

