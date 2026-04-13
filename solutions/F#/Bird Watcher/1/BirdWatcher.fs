module BirdWatcher

let lastWeek: int[] = [| 0; 2; 5; 3; 7; 8; 4 |]

let yesterday(counts: int[]): int =
  match Array.tryItem (counts.Length - 2) counts with
  | Some count -> count
  | None -> 0

let total(counts: int[]): int = Array.sum counts

let dayWithoutBirds(counts: int[]): bool =
  counts
  |> Array.exists (fun count -> count = 0)

let incrementTodaysCount(counts: int[]): int[] =
  let today = Array.last counts
  counts[counts.Length - 1] <- (today + 1)
  counts

let unusualWeek(counts: int[]): bool =
  match counts with
  | [| _; 0; _; 0; _; 0; _; |] -> true
  | [| _; 10; _; 10; _; 10; _; |] -> true
  | [| 5; _; 5; _; 5; _; 5; |] -> true
  | _ -> false
  
