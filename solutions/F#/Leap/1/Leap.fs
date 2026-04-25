module Leap

let leapYear (year: int): bool =
    let divisibleBy num = year % num = 0
    match (divisibleBy 4, divisibleBy 100, divisibleBy 400) with
    | (true, false, _) -> true
    | (true, true, true) -> true
    | _ -> false