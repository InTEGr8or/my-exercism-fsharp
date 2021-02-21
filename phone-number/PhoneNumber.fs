module PhoneNumber
open System
open System.Text.RegularExpressions

type Phone(input:string) = 
    member this.Text:string = Regex.Replace(input, "[+ \.\-\(\)]", "")
    member this.Length:int = String.length(this.Text)
    member this.Country:string option= 
        match this.Length with
            | 11 -> Some(this.Text.Substring(0, 1))
            | _ -> None
    member this.Area:string =
        match this.Length with
            | 11 -> this.Text.Substring(1,3)
            | _ -> this.Text.Substring(0,3)
    member this.Exchange:string =
        match this.Length with
            | 11 -> this.Text.Substring(4,3)
            | _ -> this.Text.Substring(3,3)

let clean (input:string): Result<uint64,string> = 
    //This all seems a bit verbose. I can't wait to check this in to look at how other people solved this problem.
    let phone = Phone(input);
    match phone with
        | _ when phone.Length < 10 -> Error "incorrect number of digits"
        | _ when phone.Length > 11 -> Error "more than 11 digits"
        | _ when Regex.Match(phone.Text, "[a-zA-Z]").Length > 0 -> Error "letters not permitted"
        | _ when Regex.Match(phone.Text, "[^\d]").Length > 0 -> Error "punctuations not permitted"
        | _ when phone.Area.[0] = '0' -> Error "area code cannot start with zero"
        | _ when phone.Area.[0] = '1' -> Error "area code cannot start with one"
        | _ when phone.Exchange.[0] = '0' -> Error "exchange code cannot start with zero"
        | _ when phone.Exchange.[0] = '1' -> Error "exchange code cannot start with one"
        | _ when phone.Length = 11 && phone.Text.[0] <> '1' -> Error "11 digits must start with 1"
        | _ when phone.Country = None -> Ok (uint64 phone.Text)
        | _ when phone.Length = 11 -> Ok (uint64(String.Join("", phone.Text.[1..])))
        | _ -> Error "incorrect number of digits"