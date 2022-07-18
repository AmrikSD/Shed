namespace Game

module main = 
    open Deck

    [<EntryPoint>]
    let main _ =
        printfn "%s" "hi"
        let deck = FreshDeck
        deck |> List.iter( fun card -> printfn "%A" card)
        printfn "%i" (List.length deck)

        let shuffled = FreshDeck |> shuffle
        shuffled |> List.iter( fun card -> printfn "%A" card)
        printfn "%i" (List.length shuffled)
        0