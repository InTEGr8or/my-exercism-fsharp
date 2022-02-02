module Bob
open System.Text.RegularExpressions


let Match pattern input =
    let m = Regex.Match(input, pattern) in
    m.Success && m.Length > 0

let response (input: string): string = 
    match input with
    | i when i.Trim() = "" -> "Fine. Be that way!"
    | i when Match "[a-zA-Z]" i 
        |> not
        && i.Trim().EndsWith("?") -> "Sure."
    | i when Match "[a-zA-Z]" input 
        |> not -> "Whatever."
    | i when i.ToUpper() = i 
        && i.Trim().EndsWith("?") -> "Calm down, I know what I'm doing!"
    | i when i.Trim().EndsWith("?") -> "Sure."
    | i when i.ToUpper() = i -> "Whoa, chill out!"
    | _ -> "Whatever."