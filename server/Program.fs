namespace Game

open Types.Players
open Players
open Deck

module main =
    [<EntryPoint>]
    let main _ =
        printfn "%s" "hi"
        let deck = FreshDeck
        deck |> List.iter( fun card -> printfn "%A" card)
        printfn "%i" (List.length deck)

        let shuffled = FreshDeck |> shuffle
        shuffled |> List.iter( fun card -> printfn "%A" card)
        printfn "%i" (List.length shuffled)
        
        let Amrik: Player = newPlayer "Amrik"
        printfn "%A" Amrik


        0