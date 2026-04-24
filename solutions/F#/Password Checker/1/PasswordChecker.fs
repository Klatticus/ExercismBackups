module PasswordChecker

open System

type PasswordError =
    | LessThan12Characters
    | MissingUppercaseLetter
    | MissingLowercaseLetter
    | MissingDigit
    | MissingSymbol
    
let (|StringMissing|_|) checkFn input = not <| String.exists checkFn input

/// Validate the given password against the rules defined in the instructions. If it meets all
/// of the rules, return a result indicating success; otherwise return a result indicating
/// failure and an error indicating which rule was violated.
let checkPassword (password: string) : Result<string, PasswordError> =
    let symbolCheck letter = List.contains letter ['!';'@';'#';'$';'%';'^';'&';'*']
    match password with
    | short when short.Length < 12 -> Error LessThan12Characters
    | StringMissing Char.IsUpper -> Error MissingUppercaseLetter
    | StringMissing Char.IsLower -> Error MissingLowercaseLetter
    | StringMissing Char.IsDigit -> Error MissingDigit
    | StringMissing symbolCheck -> Error MissingSymbol
    | _ -> Ok password

/// Return a human-readable message indicating the meaning of the given result value.
let getStatusMessage (result: Result<string, PasswordError>) : string =
    match result with
    | Ok _ -> "OK"
    | Error LessThan12Characters -> "Error: does not have at least 12 characters"
    | Error MissingUppercaseLetter -> "Error: does not have at least one uppercase letter"
    | Error MissingLowercaseLetter -> "Error: does not have at least one lowercase letter"
    | Error MissingDigit -> "Error: does not have at least one digit"
    | Error MissingSymbol -> "Error: does not have at least one symbol"
