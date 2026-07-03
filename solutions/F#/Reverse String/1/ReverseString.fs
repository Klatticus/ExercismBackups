module ReverseString

let rec listReverse listToReverse accumulator =
    match listToReverse with
    | head::tail -> listReverse tail (head::accumulator)
    | [] -> accumulator

let defaultListReverse listToReverse = listReverse listToReverse []

let reverse (input: string): string =
    input
    |> Seq.toList
    |> defaultListReverse
    |> System.String.Concat