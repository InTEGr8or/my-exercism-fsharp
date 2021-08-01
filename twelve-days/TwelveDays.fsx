    let Gifts = [
        "a Partridge in a Pear Tree.";
        "two Turtle Doves";
        "three French Hens";
        "four Calling Birds";
        "five Gold Rings";
        "six Geese-a-Laying";
        "seven Swans-a-Swimming";
        "eight Maids-a-Milking";
        "nine Ladies Dancing";
        "ten Lords-a-Leaping";
        "eleven Pipers Piping";
        "twelve Drummers Drumming"
    ]
    let subtract subtrahend minuend = minuend - subtrahend
    let Ordinal = [|
        "first";"second";"third";"fourth";"fifth";"sixth";"seventh";"eighth";"ninth";"tenth";"eleventh";"twelfth"
    |]
    let Preamble dayof = 
        $"On the %s{Ordinal.[dayof]} day of Christmas my true love gave to me: " 

    let dayGifts day =
        match day with
        | 0 -> Gifts.[0]
        | _ -> (Gifts.[1..day] |> Seq.rev |> Seq.reduce (fun acc gift -> acc + ", " + gift)) + ", and " + Gifts.[0]

    let recite start stop = 
        [(start |> subtract 1)..(stop |> subtract 1)] |> Seq.map (fun i -> (Preamble i) + (dayGifts i)) 