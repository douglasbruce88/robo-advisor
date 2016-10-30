namespace WebApp

open WebSharper

module Server =

    [<Rpc>]
    let GetChart()  = ChartData.combined()
