module Pangram

let isPangram (input: string): bool =
    input
    |> String.filter System.Char.IsLetter
    |> _.ToLower()
    |> Seq.distinct
    |> Seq.length
    |> Operators.(=) 26