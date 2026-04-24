module ResistorColor

let colors: string list = ["black"; "brown"; "red"; "orange"; "yellow"; "green"; "blue"; "violet"; "grey"; "white"]

let caseInsensitiveStringCompare a b = System.String.Equals(a, b, System.StringComparison.OrdinalIgnoreCase)

let colorCode (color: string): int =
    match List.tryFindIndex (caseInsensitiveStringCompare color) colors with
    | Some index -> index
    | None -> -1
