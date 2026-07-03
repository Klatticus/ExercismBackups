module Bob
open System

let isQuestion (text: string) =
    text
    |> _.TrimEnd()
    |> _.EndsWith('?')
    
let isYelling text =
    let filteredText = String.filter Char.IsLetter text
    (String.length filteredText <> 0) && (String.forall Char.IsUpper filteredText)

let response (input: string): string =
    match (isQuestion input, isYelling input, String.IsNullOrWhiteSpace(input)) with
    | (true, false, false) -> "Sure."
    | (false, true, false) -> "Whoa, chill out!"
    | (true, true, false) -> "Calm down, I know what I'm doing!"
    | (_, _, true) -> "Fine. Be that way!"
    | _ -> "Whatever."