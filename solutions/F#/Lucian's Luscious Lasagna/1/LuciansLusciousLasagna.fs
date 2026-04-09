module LuciansLusciousLasagna

let expectedMinutesInOven = 40

let remainingMinutesInOven timeInOven = expectedMinutesInOven - timeInOven

let preparationTimeInMinutes numberOfLayers =
    let minutesPerLayer = 2
    numberOfLayers * minutesPerLayer

let elapsedTimeInMinutes numberOfLayers minutesInOven =
    numberOfLayers
    |> preparationTimeInMinutes
    |> Operators.(+) minutesInOven