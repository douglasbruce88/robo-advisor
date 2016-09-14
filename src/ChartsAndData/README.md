# Charts and data

- Getting and working with data
  - Type providers
  - Functional collections
  - Statistics packages
    - Deedle
    - MathNet
  - Testing
    - NUnit, FSCheck, Unquote
- Charting
  - FSharp.Charting, XPlot, Excel
  - WinForms interop
- Useful links
  - Talks
  - Blogs
  - Documentation
  - Open source frameworks

## Step-by-step tutorial

#### Getting Started

- Create a new F# project
- Change it to be a 'Windows Application'
- Add reference to `System.Windows.Forms`
- Form with `[<AutoOpen>]` attribute
- Program with `[<STAThread>]`

#### Charting data

- Add FSharp.Charting NuGet package
- Add reference to `System.Windows.Forms.DataVisualization` and `System.Drawing`
- Create test data using tuples, create line chart, create chart control, `[<AutoOpen>]` module
- Create and format panel, add the chart control to it, add panel to the form
- What can we do with `FSharp.Charting`? http://fslab.org/FSharp.Charting/index.html

#### Reading data
