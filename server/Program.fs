namespace Game

open Deck
open Websocket

module main =
    open System

    [<EntryPoint>]
    let main args =
        if args.Length <> 2 then
            failwith "Provide 2 args, ip and port"
        else
            let ip = args[0]
            let port = args[1] |> int

            let deck = FreshDeck |> shuffle
            printfn "%A" (deck |> List.length)

            let amrik = "Amrik"
            let kate = "Kate"
            let arj = "Arj"
            let nyk =  "Nyk"
            let karlis =  "Karlis"

            let players = [amrik ; kate ; arj ; nyk ; karlis]

            let game = Game.buildGame players
            printfn "%A" game

            let wssv = websocket.createServer ip port
            wssv.Start()
            
            wssv.AddWebSocketService<Chat> "/chat"
            
            printfn "Press any key to close"
            let hi = Console.ReadKey()



            wssv.Stop()
            0
