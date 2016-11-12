#r "FSharp.PowerPack.Compatibility.dll"

let wordCount text =
    let words = String.split[' '] text
    let wordSet = Set.ofList words
    let numOfWords = words.Length    
    let numOfDuplicateWords = numOfWords-wordSet.Count
    (numOfWords,numOfDuplicateWords)


//let numOfDistinctWords = wordSet.Count
    
// let wordCount text =
//     let words = String.split[' '] text
//     let wordSet = Set.ofList words
//     let nWords = words.Length
//     let nDups  = words.Length - wordSet.Count
//     (nWords,nDups)
