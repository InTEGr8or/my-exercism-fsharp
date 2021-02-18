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
        | phone when phone.Length < 10 -> Error "incorrect number of digits"
        | phone when phone.Length > 11 -> Error "more than 11 digits"
        | stripped when Regex.Match(phone.Text, "[a-zA-Z]").Length > 0 -> Error "letters not permitted"
        | stripped when Regex.Match(phone.Text, "[^\d]").Length > 0 -> Error "punctuations not permitted"
        | phone when phone.Area.ToCharArray().[0] = '0' -> Error "area code cannot start with zero"
        | phone when phone.Area.ToCharArray().[0] = '1' -> Error "area code cannot start with one"
        | phone when phone.Exchange.ToCharArray().[0] = '0' -> Error "exchange code cannot start with zero"
        | phone when phone.Exchange.ToCharArray().[0] = '1' -> Error "exchange code cannot start with one"
        | phone when phone.Length = 11 && phone.Text.ToCharArray().[0] <> '1' -> Error "11 digits must start with 1"
        | phone when phone.Country = None -> Ok (uint64 phone.Text)
        | phone when phone.Length = 11 -> Ok (uint64(String.Join("", phone.Text.ToCharArray().[1..])))
        | _ -> Error "incorrect number of digits"