namespace Types

module Cards =
    type Suit =
        | Diamond
        | Club
        | Heart
        | Spade

    type Rank =
        | Ace
        | Two
        | Three
        | Four
        | Five
        | Six
        | Seven
        | Eight
        | Nine
        | Ten
        | Jack
        | Queen
        | King

    type Card = Suit * Rank

    type Deck = Card list
    type Hand = Hand of Deck
