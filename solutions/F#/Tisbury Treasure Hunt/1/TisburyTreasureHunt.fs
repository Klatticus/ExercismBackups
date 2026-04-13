module TisburyTreasureHunt

open System

let getCoordinate (line: string * string): string = line |> snd

let convertCoordinate (coordinate: string): int * char = 
    let num =
        coordinate
        |> _.Chars(0)
        |> Char.GetNumericValue
        |> int
    (num, coordinate.Chars(1))

let compareRecords (azarasData: string * string) (ruisData: string * (int * char) * string) : bool = 
    let azarasCoord = azarasData |> getCoordinate |> convertCoordinate
    let (_, ruisCoord, _) = ruisData
    azarasCoord = ruisCoord
    

let createRecord (azarasData: string * string) (ruisData: string * (int * char) * string) : (string * string * string * string) =
    if compareRecords azarasData ruisData then
        let (azarasTreasure, azarasCoord) = azarasData
        let (ruisLocation, _ruisCoord, ruisQuad) = ruisData
        (azarasCoord, ruisLocation, ruisQuad, azarasTreasure)
    else
        ("", "", "", "")
