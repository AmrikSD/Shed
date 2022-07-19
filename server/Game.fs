namespace Game

open Types.Cards
open Types.Players
open Types.Game

open Players


module Deck =

    let FreshDeck: Deck =
        let suits: Suit list = [ Diamond; Club; Heart; Spade ]

        let ranks: Rank list =
            [ Ace
              Two
              Three
              Four
              Five
              Six
              Seven
              Eight
              Nine
              Ten
              Jack
              Queen
              King ]

        List.allPairs suits ranks

    let shuffle (deck: Deck) : Deck =
        let rnd = System.Random()

        deck
        |> List.sortBy (fun _ -> rnd.Next(1, List.length deck))

    // Takes a list of players and deals them each a hand, downfacing and upfacing
    let drawCardToSpecificHand (player: Player) (hand: Hands) (deck: Deck) : Player * Deck =

        let card = List.head deck
        let leftOverCards = List.tail deck

        let playerWithNewHand: Player =
            match hand with
            | Hand ->
                { Name = player.Name
                  Hand = card :: player.Hand
                  Upfacing = player.Upfacing
                  Downfacing = player.Downfacing }
            | Upfacing ->
                { Name = player.Name
                  Hand = player.Hand
                  Upfacing = card :: player.Upfacing
                  Downfacing = player.Downfacing }
            | Downfacing ->
                { Name = player.Name
                  Hand = player.Hand
                  Upfacing = player.Upfacing
                  Downfacing = card :: player.Downfacing }

        playerWithNewHand, leftOverCards

    // Takes a list of players and gives them each a hand, upfacing and downfacing, as well as the remaining deck
    let deal (players: Player list) (deck: Deck) : Player list * Deck =

        match (players |> List.length > 5) with
        | true -> failwith "Only 5 players max"
        | false ->
            let (players: Player list), newDeck =
                (deck, players)
                ||> List.mapFold (fun acc player ->

                    // Take 9 cards, split into 3 piles of 3, make sure to update the deck each time
                    let top3, remaining = acc |> List.splitAt 3
                    let snd3, remaining = remaining |> List.splitAt 3
                    let third3, remaining = remaining |> List.splitAt 3


                    // Then put each of the piles of 3 into the players hand/upfacing/downfacing
                    let newp =
                        { Name = player.Name
                          Hand = top3
                          Upfacing = snd3
                          Downfacing = third3 }


                    newp, remaining)

            players, newDeck



    // Deals one card to the players hand
    let takeCard (player: Player) (deck: Deck) : Player * Deck =

        let card = List.head deck
        let leftOverCards = List.tail deck
        let newHand = card :: player.Hand

        let playerWithNewHand: Player =
            { Name = player.Name
              Hand = newHand
              Upfacing = player.Upfacing
              Downfacing = player.Downfacing }

        playerWithNewHand, leftOverCards


module Game =
    /// Takes a list of players and returns a starting game state
    let buildGame (players: string List) : Game =

        // Start with a fresh deck, shuffle it
        let deck = Deck.FreshDeck |> Deck.shuffle

        // Create all of the player objects
        let players, deck =
            players |> List.map newPlayer |> Deck.deal <| deck

        // Returns the game object, default to the head as the starting player
        { Players = players
          Turn = players |> List.head
          Deck = deck }
