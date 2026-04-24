module KindergartenGarden

open System

type Plant =
    | Grass
    | Clover
    | Radishes
    | Violets
    | Unknown
    
let encodingToPlant letter =
    match letter with
    | 'G' -> Grass
    | 'C' -> Clover
    | 'R' -> Radishes
    | 'V' -> Violets
    | _ -> Unknown

let parseRowIntoPairs row =
    row
    |> Seq.map encodingToPlant
    |> Seq.chunkBySize 2
    
let studentOffset student =
    match student |> Seq.head |> Char.ToLower with
    | 'a' -> 0
    | 'b' -> 1
    | 'c' -> 2
    | 'd' -> 3
    | 'e' -> 4
    | 'f' -> 5
    | 'g' -> 6
    | 'h' -> 7
    | 'i' -> 8
    | 'j' -> 9
    | 'k' -> 10
    | 'l' -> 11
    | 'm' -> 12
    | 'n' -> 13
    | 'o' -> 14
    | 'p' -> 15
    | 'q' -> 16
    | 'r' -> 17
    | 's' -> 18
    | 't' -> 19
    | 'u' -> 20
    | 'v' -> 21
    | 'w' -> 22
    | 'x' -> 23
    | 'y' -> 24
    | 'z' -> 25
    | _ -> 0
    
let getCupPairForStudent student pairCollection =
    let searchIndex = studentOffset student
    pairCollection |> Seq.item searchIndex

let plants (diagram:string) student =
    diagram
    |> _.Split('\n')
    |> Array.map parseRowIntoPairs
    |> Array.collect (getCupPairForStudent student)
    |> Array.toList