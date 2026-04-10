module CarsAssemble

open System

let successRate (speed: int): float =
    if speed > 0 && speed < 5 then 1.0
    elif speed > 0 && speed < 9 then 0.9
    elif speed = 9 then 0.8
    elif speed = 10 then 0.77
    else 0.0

let productionRatePerHour (speed: int): float =
    float speed * 221.0 * successRate speed

let workingItemsPerMinute (speed: int): int =
    let flippedDivision x y = y / x
    speed
    |> productionRatePerHour
    |> flippedDivision 60.0
    |> floor
    |> int
