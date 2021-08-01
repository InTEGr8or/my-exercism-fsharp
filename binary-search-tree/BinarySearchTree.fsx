open System

// https://lukemerrett.com/fsharp-binary-search-tree/

type Leaf = { 
    value:int; 
    left:Leaf option; 
    right:Leaf option}

let rec insertLeaf (tree:Leaf option) (newValue:int) : Leaf  =
    match tree with 
    | Some t -> if newValue < t.value 
                    then {t with left=Some (insertLeaf t.left newValue)}
                else if newValue > t.value 
                    then {t with right=Some (insertLeaf t.right newValue)}
                else t
    | None -> {value=newValue; left=None; right=None}

let tree = [50; 34; 70; 20; 6; 23; 102] 
           |> List.fold (fun acc item -> Some (insertLeaf acc item)) None

let left node  = failwith "Implement"

let right node = failwith "You need to implement this function."

let data node option = failwith "You need to implement this function."

let create items = failwith "You need to implement this function."

let sortedData node = failwith "You need to implement this function."


