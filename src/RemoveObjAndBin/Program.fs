module Program


[<EntryPoint>]
let main argv =
    let res = File.findBinAndObjDictionary "/home/dominikus1993/projekty"
    printfn "Hello from F# %A" res
    0