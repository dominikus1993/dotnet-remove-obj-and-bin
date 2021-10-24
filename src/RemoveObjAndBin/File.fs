module File
open System.IO
open Utils

let findBinAndObjDictionary(dir: string) =
    let info = DirectoryInfo(dir);
    info.GetDirectories("*", SearchOption.AllDirectories)
        |> Array.filter(fun x -> x.Name |> String.eq "obj" || x.Name |> String.eq "bin")
        |> Array.map(fun x -> x.ToString())