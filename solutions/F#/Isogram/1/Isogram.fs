module Isogram

let isIsogram (str: string): bool =
    let filteredString =
        str
        |> String.filter System.Char.IsLetter
        |> _.ToLower()
    let letterSet = set filteredString
    letterSet.Count = filteredString.Length