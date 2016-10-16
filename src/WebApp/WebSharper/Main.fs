namespace Bundle1

open WebSharper
open WebSharper.Html

[<JavaScript; SPAEntryPoint>]
module HelloWorld =
    open WebSharper.Html.Client

    let Main =
        let welcome = P [Text "Welcome"]
        Div [
            welcome
            Button [Text "Click Me!"]
            |>! OnClick (fun e args ->
                welcome.Text <- "Hello, world!")
        ]
        |> fun res -> res.AppendTo "entrypoint"