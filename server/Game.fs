namespace Game

open Cards
open Helpers

module Deck =

    let FreshDeck: Deck =
        let suits: Suit list = [Diamond;Club;Heart;Spade]
        let ranks: Rank list = [Ace;Two;Three;Four;Five;Six;Seven;Eight;Nine;Ten;Jack;Queen;King]

        Lists.cartesian suits ranks
        

    let shuffle (deck: Deck) : Deck =
        let rnd = System.Random()
        deck |> List.sortBy (fun _ -> rnd.Next(1, List.length deck))