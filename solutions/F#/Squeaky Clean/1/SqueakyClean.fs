module SqueakyClean

open System

let transform (c: char) : string =
    match c with
    | '-' -> "_"
    | space when Char.IsWhiteSpace(space) -> ""
    | upper when Char.IsUpper(upper) -> $"-{Char.ToLower(upper)}"
    | num when Char.IsNumber(num) -> ""
    | greek when Char.IsLower(greek) && (int greek >= 880 && int greek <= 1023) -> "?"
    | _ -> c.ToString()
    
let clean (identifier: string): string = String.collect transform identifier
