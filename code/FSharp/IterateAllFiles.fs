let IterateAllFiles path =
    System.IO.Directory.GetFiles(path) |> Array.map( fun file -> pringf "%s" file)
