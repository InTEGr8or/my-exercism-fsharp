module Hamming
open System

let distance (strand1: string) (strand2: string): int option = 
    match (strand1, strand2) with
        | strand1, strand2 when String.length strand1 <> String.length strand2 -> None
        | _ -> seq {for i in [0..(String.length strand1 - 1)] do if strand1.[i] <> strand2.[i] then yield 1} |> Seq.sum |> Some

