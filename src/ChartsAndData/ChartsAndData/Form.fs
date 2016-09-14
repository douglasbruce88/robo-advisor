namespace ChartsAndData

[<AutoOpen>]
module Form = 
    open System.Windows.Forms
    open System.Drawing

    let form = new Form(Name = "Main", Visible = true, Text = "Tickers", AutoScaleDimensions = SizeF(6.F, 13.F), AutoScaleMode = AutoScaleMode.Font, ClientSize = Size(1000, 600))

    let panel = new Panel(Location = new Point(0, 0), Size = new Size(800, 600), BorderStyle = BorderStyle.Fixed3D, Dock = DockStyle.Fill)
    panel.Controls.Add Charting.chartControl

    form.Controls.Add panel

    let load() = form