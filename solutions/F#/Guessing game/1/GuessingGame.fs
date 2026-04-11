module GuessingGame

let reply (guess: int): string =
    match guess with
    | 42 -> "Correct"
    | 41 | 43 -> "So close"
    | low when low < 41 -> "Too low"
    | high when high > 43 -> "Too high"