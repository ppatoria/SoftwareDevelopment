open System.Windows.Forms
open System.IO
open System.Net

let form =
    new Form (Visible = true, TopMost = true, Text    = "Welcome to F#")

let textB =
    new RichTextBox (Dock = DockStyle.Fill, Text = "Here is some initial text")

form.Controls.Add textB 

/// Get the contents of the URL via a web request
let http (url: string) =
    let req    = System.Net.WebRequest.Create (url)
    let resp   = req.GetResponse              ()
    let stream = resp.GetResponseStream       ()
    let reader = new StreamReader             (stream)
    let html   = reader.ReadToEnd             ()
    resp.Close()
    html

/// Get the contents of the URL via a web request
let http (url: string) =
    WebRequest.Create (url)
    .GetResponse ()                 
    .GetResponseStream ()
    .Close ()

let html (stream: TextStream)
    new StreamReader (stream)
    .reader.ReadToEnd ()

http "http://news.bbc.co.uk"
|> html
|> textB.Text

textB.Text <- http "http://news.bbc.co.uk" 
