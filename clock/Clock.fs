module Clock


let create hours minutes = 
    let clock = (minutes + hours*60) % (24*60)
    if clock < 0 then clock + (24*60) else clock

let add minutes clock = 
    clock + minutes

let subtract minutes clock = 
    if clock - minutes < 
        then clock - (minutes % (24*60)) + (24*60) 
        else clock - minutes

let display clock = 
    let hours = clock / 60
    let minutes = clock % 60
    let hoursString = (hours % 24 + 100 |> string)[1..2]
    let minutesString = (minutes + 100 |> string)[1..2
    hoursString + ":" + minutesString