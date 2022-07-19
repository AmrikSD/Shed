namespace Game

open Types.Players

module Players =

    // Takes a Name and Gives back a player with no hand
    let newPlayer (name: string) : Player =
        { Name = name
          Hand = []
          Upfacing = []
          Downfacing = [] }
