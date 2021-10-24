module Model
open System.Runtime.InteropServices

type Os = 
    | Windows
    | Linux
    | MacOs
    | Unknown

let checkOs (): Os =
    if RuntimeInformation.IsOSPlatform(OSPlatform.Linux) then
        Linux
    elif RuntimeInformation.IsOSPlatform(OSPlatform.Windows) then
        Windows
    elif RuntimeInformation.IsOSPlatform(OSPlatform.OSX)  then
        MacOs
    else 
        Unknown