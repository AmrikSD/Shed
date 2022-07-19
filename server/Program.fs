namespace Game

open Types.Players
open Players
open Types.Game
open Deck

module main =
    [<EntryPoint>]
    let main _ =

        let deck = FreshDeck |> shuffle
        printfn "%A" (deck |> List.length)

        let amrik: Player = newPlayer "Amrik"
        printfn "%A" amrik
        let kate: Player = newPlayer "kate"
        printfn "%A" kate


        let players, deck = deal [ amrik; kate ] deck
        printfn "%A" players
        printfn "%A" deck
        printfn "%A" (deck |> List.length)

        0
