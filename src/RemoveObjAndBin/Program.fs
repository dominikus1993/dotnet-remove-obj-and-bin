module Program

open Argu
open System
open Directory

type CmdArgs =
    | [<CliPrefix(CliPrefix.None)>] Rm of dir: string
with
    interface IArgParserTemplate with
        member this.Usage =
            match this with
            | Rm _ -> "Remove all obj and bin catalogs"

type CliError =
    | ArgumentsNotSpecified of msg: string
    | RemoveDirError of exc: exn

let removeDirs (dir: Dir) =
    try
        printfn "Remove all obj and bin catlogs from dir %s" dir
        let res = findBinAndObj "/home/dominikus1993/projekty/tst"
                    |> rm        
                    |> Seq.toArray
        Ok(res)
    with
    | ex -> Error(RemoveDirError(ex))

let getExitCode (result: Result<Dir array, CliError>) =
    match result with
    | Ok res -> 
        printfn "Obj and Bin catalogs removed %A" res
        0
    | Error(RemoveDirError(exc)) ->
        printfn "ERROR!!!! %s" exc.Message
        1
    | Error(ArgumentsNotSpecified(msg)) ->
        printfn "Argument not specified %s" msg
        1



[<EntryPoint>]
let main argv =
    let errorHandler = ProcessExiter(colorizer = function ErrorCode.HelpText -> None | _ -> Some ConsoleColor.Red)
    let parser = ArgumentParser.Create<CmdArgs>(programName = "remove-obj-bin", errorHandler = errorHandler)
    let res = match parser.ParseCommandLine argv with
              | p when p.Contains(Rm) ->  removeDirs (p.GetResult(Rm))
              | _ ->
                Error(ArgumentsNotSpecified(parser.PrintUsage()))
    res |> getExitCode