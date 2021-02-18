module Hamming
open System

let distance (strand1: string) (strand2: string): int option = 
    match (strand1, strand2) with
        | strand1, strand2 when String.length strand1 <> String.length strand2 -> None

