open System
type Node<'a> =
    | Empty
    | Node of Data:'a * Left:Node<'a> * Right:Node<'a>

let data = function Empty -> failwith "Empty Tree" | Node (d, _, _) -> d
let left = function Empty -> Empty | Node (_, l, _) -> l
let right = function Empty -> Empty | Node (_, _, r) -> r

let first root = 
    let rec goLeft node =
        match node with
        | Empty -> None
        | Node (d, ln, _) ->
            match ln with
            | Empty -> Some d
            | Node _ -> goLeft ln

    goLeft root

let last root = 
    let rec goRight node =
        match node with
        | Empty -> None
        | Node (d, _, rn) ->
            match rn with
            | Empty -> Some d
            | Node _ -> goRight rn

    goRight root

let rec insert data root =
    match root with
    | Empty -> Node(data, Empty, Empty)
    | Node (d, l, r) ->
        match data <= d with
        | true -> Node (d, l |> insert data, r)
        | false -> Node (d, l, r |> insert data)

let toOrderedSeq root =
    let rec dfs node =
        match node with
        | Empty -> Seq.empty
        | Node (d, ln, rn) -> seq {
                yield! dfs ln
                yield d
                yield! dfs rn
            }

    dfs root

let toBinaryTree data = data |> List.fold (fun n x -> n |> insert x) Empty
let testTree = toBinaryTree [1;3;5;4;7;8;56;34;23;43;12]
let validInt = Some 5

validInt.Value
