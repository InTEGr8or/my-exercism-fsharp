module Grains

let square (n: int): Result<uint64,string> = 
    if (List.contains n [1..64]) then Ok (pown 2UL (n - 1))
    else Error "square must be between 1 and 64"

let total: Result<uint64,string> = 
    Ok ([0..63] |> List.sumBy(fun i -> pown 2UL i))
