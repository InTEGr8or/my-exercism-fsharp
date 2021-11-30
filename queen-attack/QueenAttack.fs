module QueenAttack

let create (x, y): bool = 
    (
        x > 7 
        || x < 0 
        || y > 7 
        || y < 0
    ) 
    |> not

let canAttack ((x1, y1) as q1) ((x2, y2) as q2) = 
    let dx = x2 - x1
    let dy = y2 - y1
    x1 = x2 
    || y1 = y2 
    || dy/dx |> abs = 1 