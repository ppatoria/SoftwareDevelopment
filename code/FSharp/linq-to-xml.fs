open System
open System.Xml
open System.Xml.Linq

let weatherXml =    
    //"http://weather.yahooapis.com/forecastrss?w=2484280" |>
     XDocument.Load("c:/Users/Pralay/Documents/Projects/FSharp/searchPattern.xml")

let readTheElements =
    weatherXml.Elements("SearchPattern") |>
    Seq.iter(fun(e) -> do printfn "%s" e.Value)
    // Seq.iter(fun(e) -> do e.Attributes.ToString()) // |>
             // Seq.iter(fun(a) -> do printfn "%d" a.Count ))
