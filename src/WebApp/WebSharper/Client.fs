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

open WebSharper
open WebSharper.JavaScript
open WebSharper.JQuery
open WebSharper.Highstock

[<JavaScript>]
[<Require(typeof<Resources.Highstock>)>]
[<Require(typeof<Resources.ExportingModule>)>]
module StockControl =

    let Main () =
        let chartDiv = div [ divAttr [ attr.``class`` "jumbotron"; attr.height "100%" ] [] ] 
        JQuery.GetJSON("http://www.highcharts.com/samples/data/jsonp.php?filename=aapl-c.json&callback=?",
            fun (data,_) -> 
                Highcharts.Create(JQuery.Of chartDiv.Dom,
                    HighstockCfg(
                        Title = TitleCfg(
                            Text = "AAPL stock price"
                        ),
                        RangeSelector = RangeSelectorCfg(
                            Selected = 1.,
                            InputEnabled = ((JQuery.Of chartDiv.Dom).Width() > 480)
                        ),
                        Series = [|
                            SeriesCfg(
                                Name = "AAPL",
                                Data = As data
                            )
                        |]
                    )
                ) |> ignore
        ) |> ignore
        chartDiv
