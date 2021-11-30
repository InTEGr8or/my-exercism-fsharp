module CarsAssemble

let rph = 221.0
let successRate (speed: int): float =
    match speed with
    | 0 -> 0.0
    | 1 | 2 | 3 | 4 -> 1.0
    | 5 | 6 | 7 | 8 -> 0.9
    | 9 -> 0.8
    | 10 -> 0.77
    | _ -> failwith "Input speed outside range"


let productionRatePerHour (speed: int): float =
    (successRate speed) * rph * (speed |> float)

let workingItemsPerMinute (speed: int): int =
    (productionRatePerHour speed) / 60.0 |> int
