module Directory
open System.IO
open Utils

type Dir = string
type Dirs = Dir seq

let findBinAndObj(dir: Dir): Dirs =
    let info = DirectoryInfo(dir);
    info.GetDirectories("*", SearchOption.AllDirectories)
        |> Array.filter(fun x -> x.Name |> String.eq "obj" || x.Name |> String.eq "bin")
        |> Array.map(fun x -> x.ToString())
        |> Array.toSeq

let rm (dirs: Dirs) : Dirs =
    seq {
        for dir in dirs do
            Directory.Delete(dir)
            yield dir
    }