module Pangram

let isPangram (input: string): bool =
    Seq.length (seq { for x in ['a'..'z'] do if not <| Seq.contains x (seq(input.ToLower())) then yield false }) = 0