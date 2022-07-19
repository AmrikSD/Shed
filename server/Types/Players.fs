namespace Types

open Cards

module Players =

    type Player =
        { Name: string
          Hand: Deck
          Upfacing: Deck
          Downfacing: Deck }

    type Hands =
        | Hand
        | Upfacing
        | Downfacing
