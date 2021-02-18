module TwoFer


let twoFer (input: string option): string = 
    $"""One for {input |> Option.defaultValue "you"}, one for me.""";;




