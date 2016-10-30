namespace UINextApplication1

open WebSharper
open WebSharper.JavaScript
open WebSharper.JQuery
open WebSharper.UI.Next
open WebSharper.UI.Next.Client

[<JavaScript>]
module Client =    
    open WebSharper.Charting

    type IndexTemplate = Templating.Template<"index.html">

    let Main =
        JQuery.Of("#main").Empty().Ignore

        Chart.Combine [
            Chart.Line([for x in 1.0 .. 9.0 -> string x, x * x])
            Chart.Line([for x in 1.0 .. 9.0 -> string x, x])
                .WithFillColor(Color.Rgba(10, 10, 70, 0.5))
        ]
        |> fun ch ->
            Renderers.ChartJs.Render(ch,
                Config =
                    ChartJs.LineChartConfiguration(
                        DatasetFill = true,
                        BezierCurve = true)
        )
        |> Doc.RunById "main"
