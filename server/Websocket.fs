namespace Websocket

open System
open WebSocketSharp
open WebSocketSharp.Server

type Chat () =
    inherit WebSocketBehavior()
    override x.OnMessage(e: MessageEventArgs) =
        printfn "%A" e.Data
        // input
        x.Sessions.Broadcast(e.Data)

module websocket =

    let createServer (ip:string) (port:int): WebSocketServer =
        printfn "%s" $"Creating websocket at {ip}:{port}"
        WebSocketServer $"ws://{ip}:{port}"

