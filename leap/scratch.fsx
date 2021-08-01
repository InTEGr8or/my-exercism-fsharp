open System


let (|Leap|Exclude|) (input:int) = 
    match input % 4 with
    | 0 -> Leap
    | _ -> Exclude

let TestNumber input =
   match input with
   | Leap -> printfn "%d is Leap" input
   | Exclude -> printfn "%d is NOT Leap" input

TestNumber 2015
TestNumber 2000
TestNumber 1960

let leapYear (year: int) = year % 4 = 0 && (year % 400 = 0 || year % 100 <> 0)