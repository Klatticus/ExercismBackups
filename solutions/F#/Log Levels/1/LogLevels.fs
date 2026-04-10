module LogLevels

open System

let message (logLine: string): string =
    logLine
    |> _.Split(":")
    |> Array.last
    |> _.Trim()

let logLevel(logLine: string): string =
    logLine
    |> _.Split(":")
    |> Array.head
    |> String.filter Char.IsLetter
    |> String.map Char.ToLower

let reformat(logLine: string): string =
    (message logLine) + " (" + (logLevel logLine) + ")"
