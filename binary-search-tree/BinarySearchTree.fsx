open System

// https://lukemerrett.com/fsharp-binary-search-tree/

// https://codereview.stackexchange.com/questions/234917/f-binary-tree-and-tree-traversal

type Node<'a> =
    | None
    | Node of Data:'a * Left:Node<'a> * Right:Node<'a>

let data = function None -> failwith "Empty Tree" | Node (d, _, _) -> d
// let left = function Empty -> None | Node (_, l, _) -> Some l
let left node =
    match node with
    | Node (_, l, _) -> l
    | _ -> None

let right node = 
    match node with
    | None -> None
    | Node (_, _, r) -> r


let first root = 
    let rec goLeft node =
        match node with
        | None -> None
        | Node (d, ln, _) ->
            match ln with
            | None -> d
            | Node _ -> goLeft ln

    goLeft root

let last root = 
    let rec goRight node =
        match node with
        | None -> None
        | Node (d, _, rn) ->
            match rn with
            | None -> d
            | Node _ -> goRight rn

    goRight root

let rec insert data root =
    match root with
    | None -> Node(data, None, None)
    | Node (d, l, r) ->
        match data <= d with
        | true -> Node (d, l |> insert data, r)
        | false -> Node (d, l, r |> insert data)

let toOrderedSeq root =
    let rec dfs node =
        match node with
        | None -> Seq.empty
        | Node (d, ln, rn) -> seq {
                yield! dfs ln
                yield d
                yield! dfs rn
            }

    dfs root

let create data = 
    data 
    |> List.fold (fun n x -> n |> insert x) None 