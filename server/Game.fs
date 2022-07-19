namespace Game

open Types.Cards
open Types.Players
open Types.Game

open Players


module Deck =

    let FreshDeck: Deck =
        let suits: Suit list = [Diamond;Club;Heart;Spade]
        let ranks: Rank list = [Ace;Two;Three;Four;Five;Six;Seven;Eight;Nine;Ten;Jack;Queen;King]

        List.allPairs suits ranks

    let shuffle (deck: Deck) : Deck =
        let rnd = System.Random()
        deck |> List.sortBy (fun _ -> rnd.Next(1, List.length deck))
    
    // Takes a list of players and deals them each a hand, downfacing and upfacing
    let drawCardToSpecificHand (player: Player) (hand: Hands) (deck:Deck): Player * Deck =
            
            let card = List.head deck
            let leftOverCards = List.tail deck
            
            let playerWithNewHand: Player = 
                match hand with
                | Hand ->
                    {
                        Name= player.Name
                        Hand = card :: player.Hand
                        Upfacing = player.Upfacing
                        Downfacing = player.Downfacing
                    }
                | Upfacing ->
                    {
                        Name= player.Name
                        Hand = player.Hand
                        Upfacing = card :: player.Upfacing
                        Downfacing = player.Downfacing
                    } 
                | Downfacing ->
                    {
                        Name= player.Name
                        Hand = player.Hand
                        Upfacing = player.Upfacing
                        Downfacing = card :: player.Downfacing
                    } 

            playerWithNewHand, leftOverCards
            
    let deal (players: Player list) (deck: Deck): Player list * Deck =

        match (players |> List.length > 5) with
        | true -> failwith "Only 5 players max"
        | false ->
            players,deck

                

    // Deals one card to the players hand
    let takeCard (player: Player) (deck: Deck) : Player * Deck =
        
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
    let buildGame (players: string List) : Game  =
        
        // Start with a fresh deck, shuffle it
        let deck = Deck.FreshDeck |> Deck.shuffle

        // Create all of the player objects
        let players, deck =
            players
            |> List.map newPlayer
            |> Deck.deal <| deck
        
        // Returns the game object, default to the head as the starting player
        {
            Players = players
            Turn    = players |> List.head
            Deck    = deck
        }
