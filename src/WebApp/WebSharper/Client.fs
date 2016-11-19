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
        let chartDiv = div [ divAttr [ attr.``class`` "jumbotron"; attr.height "100%" ] [ chartElt ] ]
        div [ divAttr [ attr.``class`` "container"
                        attr.height "100%" ] [ chartDiv ] ]
