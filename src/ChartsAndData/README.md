# Charts and data

## Getting and working with data
  - Type providers
  - Functional collections
  - Statistics packages
    - Deedle
    - MathNet
  - Testing
    - NUnit, FSCheck, Unquote

## Charting
  - FSharp.Charting, XPlot, Excel
  - WinForms interop

## Useful links
  - Talks
  - Blogs
  - Documentation
  - Open source frameworks

## Step-by-step tutorial

- Let's have a look at the completed domain from the first part, the code is [here](../DomainModelling/DomainModelling.fs)
- If you get stuck, you can reference some [sample code](./ChartsAndData)
- Try to explore yourself, search for online docs (try 'F# charting'  as a keyword)

#### Getting Started

The instructions below help get you up and running, along with specific examples for Visual Studio. If you are using a different editor the steps should be the same but may need to

###### Get your project off the ground

- Create a new F# library project
  - `File` -> `New` -> `Project` -> `Visual F#` -> `Windows` -> `Library`
- Change it to be a 'Windows Application'
  - Right click on the project -> `Properties` -> `Output Type` -> `Windows Application`
- Add reference to `System.Windows.Forms`
  - Right-click on `References` within the project -> `Add Reference` -> `Framework` -> `System.Windows.Forms`

**NOTE**: If you're running your app on Mono, please see [this page](http://www.mono-project.com/docs/gui/winforms/) for information and help about using WinForms on Mono. If you wish to use GTK instead, check out instructions [here](http://www.mono-project.com/docs/gui/gtksharp/).

###### Create a blank form

In your `.fs` file, write the code below:

```fsharp
open System
open System.Windows.Forms

Application.EnableVisualStyles()
Application.SetCompatibleTextRenderingDefault false
[<STAThread>]
do Application.Run(new Form())
```

If you run your project, you should see a blank form appear!

###### Hook up your own form

Create a second file called `Form.fs`. Make sure it's above your first file in the project structure - otherwise you won't be able to use it!

Add a reference to `System.Drawing`

Write the code below to build a minimal form:

``` fsharp
namespace ChartsAndData

[<AutoOpen>]
module Form =
    open System.Windows.Forms
    open System.Drawing

    let form = new Form(Name = "Main", Visible = true, Text = "Pension Pot Valuation", AutoScaleDimensions = SizeF(6.F, 13.F), AutoScaleMode = AutoScaleMode.Font, ClientSize = Size(1000, 600))

    let panel = new Panel(Location = new Point(0, 0), Size = new Size(800, 600), BorderStyle = BorderStyle.Fixed3D, Dock = DockStyle.Fill)

    form.Controls.Add panel

    let load() = form
```

Add the line `open ChartsAndData` to your first file, and change `new Form()` to say `Form.load()` instead.

Fire up the form again and see how it's changed size and has a title.

#### Charting data

We are going to be using `FSharp.Charting`. The [http://fslab.org/FSharp.Charting/index.html](http://fslab.org/FSharp.Charting/index.html)

To get the most basic chart up and running, follow these steps:

- Add `FSharp.Charting` NuGet package (or `FSharp.Charting.Gtk` if that's more your bag)
- Add a reference to `System.Windows.Forms.DataVisualization`

Then, add a new file called `Charting.fs` and put it above the two you already have.

Write `open FSharp.Charting` and `open FSharp.Charting.ChartTypes` to access the library you've just downloaded, then type `Chart.` and check out  all the intellisense options for making charts!

###### Simple line chart

Time to draw a straight line! Add the following to your new `Charting.fs` file:

``` fsharp
open System.Windows.Forms

let line = Chart.Line[1..10]
let chartControl = new ChartControl(line, Dock = DockStyle.Fill)
```

Add this to your form by writing `panel.Controls.Add Charting.chartControl`just after you declared `panel` in `Form.fs`


###### Linking our domain

Get the domain from [here](../DomainModelling/DomainModelling.fs) and add it to your project (again above all your existing files)

Now it's over to you:
- model your own pension pot
- calculate how much it will be worth  when you retire (the sample calculation given you both 'contributions' and 'asset returns' as outputs)
- plot that against time on a combined area chart!

#### **BONUS**: Reading data

Very time dependent, we'll look at this if ahead of schedule.

- `CSVProvider` from `FSharp.Data` package
- Get example CSV from GitHub
- Import the file with `PreferOptionals` and en-gb `Culture` for dates
- Write tests: post-1978; pre-1950; in between; your birthday
- Calc SPA from date of birth
