namespace Websocket

open System
open WebSocketSharp
open WebSocketSharp.Server

// The WebSocketSharp library required you to extend a class.
// this is how that's done in F#,
// not ideal but the library is pretty nice so I'm dealing with it
type Chat() =
    inherit WebSocketBehavior()

    override x.OnMessage(e: MessageEventArgs) = x.Sessions.Broadcast(e.Data)

module websocket =

    let createServer (ip: string) (port: int) : WebSocketServer =
        printfn "%s" $"Creating websocket at {ip}:{port}"
        WebSocketServer $"ws://{ip}:{port}"
