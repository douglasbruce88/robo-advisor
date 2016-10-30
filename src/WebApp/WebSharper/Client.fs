namespace WebApp

open WebSharper
open WebSharper.JavaScript
open WebSharper.UI.Next
open WebSharper.UI.Next.Client
open WebSharper.UI.Next.Html

[<JavaScript>]
module Client = 
    open WebSharper.Charting
    
    let Main() =         
        let charts = Server.GetChart()
        let chartElt = 
            charts 
            |> fun ch -> 
                Renderers.ChartJs.Render
                    (ch, Config = ChartJs.LineChartConfiguration(DatasetFill = true, BezierCurve = true))
        div [ divAttr [ attr.``class`` "jumbotron" ] [ chartElt ] ]
