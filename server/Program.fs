namespace Game

open Types.Players
open Players
open Deck

module main =
    [<EntryPoint>]
    let main _ =
       
        let deck = FreshDeck |> shuffle
        printfn "%A" (deck |> List.length)

        let amrik: Player = newPlayer "Amrik"
        printfn "%A" amrik

        let amrik, deck = deck |> takeCard amrik

        printfn "%A" amrik
        printfn "%A" (deck |> List.length)

        0