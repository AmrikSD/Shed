namespace Game

open Types.Cards
open Types.Players
open Types.Game
open Helpers


module Deck =

    let FreshDeck: Deck =
        let suits: Suit list = [Diamond;Club;Heart;Spade]
        let ranks: Rank list = [Ace;Two;Three;Four;Five;Six;Seven;Eight;Nine;Ten;Jack;Queen;King]

        Lists.cartesian suits ranks

    let shuffle (deck: Deck) : Deck =
        let rnd = System.Random()
        deck |> List.sortBy (fun _ -> rnd.Next(1, List.length deck))
    
    
    let deal (player: Player) (deck: Deck) : Player * Deck =
        
        let card = List.head deck
        let leftOverCards = List.tail deck
        let newHand = card :: player.Hand

        let playerWithNewHand: Player = {
            Name=player.Name
            Hand = newHand
            Upfacing = player.Upfacing
            Downfacing = player.Downfacing
        }

        playerWithNewHand, leftOverCards


module Game =

    /// Takes a list of players and returns a starting game state
    let buildGame
        (players: string List)
        : Game
        =
        {
            Deck= failwith "Not implemented"
            Players = failwith "Not Implemented"
            Turn = failwith "Not Implemented"
        }
