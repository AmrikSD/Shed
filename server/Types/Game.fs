namespace Types

open Cards
open Players

module Game =

    type Game = {
        Players: Player List // The list of participating players
        Turn: Player // Whos turn it is
        Deck: Deck
    }