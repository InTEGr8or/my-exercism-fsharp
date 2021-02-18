module Isogram
    
let dedupe str = 
    str.ToString().ToLower() |> seq |> Seq.distinct

let strip str =
    str.ToString().Replace("-", "").Replace(" ", "")

let isIsogram str = 
    (Seq.length(seq(strip str)) = Seq.length(dedupe(strip str))) 


