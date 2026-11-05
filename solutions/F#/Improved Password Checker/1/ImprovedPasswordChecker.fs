module ImprovedPasswordChecker

open System

[<Flags>]
type PasswordError =
    | LessThan12Characters = 0b00001
    | MissingUppercaseLetter = 0b00010
    | MissingLowercaseLetter = 0b00100
    | MissingDigit = 0b01000
    | MissingSymbol = 0b10000

let invalidCheck checkFn input = not <| String.exists checkFn input

let validationRules = [
    ((fun input -> (String.IsNullOrEmpty input) || input.Length < 12), PasswordError.LessThan12Characters)
    (invalidCheck Char.IsUpper, PasswordError.MissingUppercaseLetter)
    (invalidCheck Char.IsLower, PasswordError.MissingLowercaseLetter)
    (invalidCheck Char.IsDigit, PasswordError.MissingDigit)
    (invalidCheck (fun letter -> List.contains letter ['!';'@';'#';'$';'%';'^';'&';'*']), PasswordError.MissingSymbol)
]

/// Validate the given password against the rules defined in the instructions. If it meets all
/// of the rules, return a result indicating success; otherwise return a result indicating
/// failure with an error value indicating all of the rules that were violated.
let checkPassword (password: string) : Result<string, PasswordError> =
    let valid = enum<PasswordError> 0
    let errors =
        validationRules
        |> List.fold (fun accumulator (checkFn, errorFlag) -> if checkFn password then accumulator ||| errorFlag else accumulator) valid
    if errors = valid then Ok password else Error errors

let phraseMap = [
    (PasswordError.LessThan12Characters, "12 characters")
    (PasswordError.MissingDigit, "digit")
    (PasswordError.MissingLowercaseLetter, "lowercase letter")
    (PasswordError.MissingSymbol, "symbol")
    (PasswordError.MissingUppercaseLetter, "uppercase letter")
]
/// Return a list of human-readable phrases indicating the meaning of the given result value.
let getStatusPhrases (result: Result<string, PasswordError>) : string list =
    let parseErrors (errorFlags:PasswordError) =
        phraseMap
        |> List.fold (fun accumulator (errorFlag, phrase) -> if errorFlags.HasFlag errorFlag then phrase::accumulator else accumulator) []
    match result with
    | Ok _ -> []
    | Error passwordErrors -> parseErrors passwordErrors
    