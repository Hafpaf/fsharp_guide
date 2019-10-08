/// Not working yet, missing anonymous function 
/// List
let rec find p xs =
    if List.isEmpty xs
    then None
    else if p (List.head xs)
        then Some (List.head xs)
        else find p (List.tail xs)

let xs [1;2;3]
printfn // anon fun