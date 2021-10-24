namespace Utils
open System

module String =
    let toLower(str: string) =
        str.ToLower()
    
    let eq (str: string) (str2: string) =
        str.Equals(str2, StringComparison.InvariantCultureIgnoreCase)