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

- Can reference code from [https://github.com/douglasbruce88/robo-advisor/tree/master/src/ChartsAndData/ChartsAndData](https://github.com/douglasbruce88/robo-advisor/tree/master/src/ChartsAndData/ChartsAndData)
- Try to explore yourself, search for online docs

#### Getting Started

- Create a new F# project
- Change it to be a 'Windows Application'
- Add reference to `System.Windows.Forms`
- Form with `[<AutoOpen>]` attribute
- Program with `[<STAThread>]`

#### Charting data

- Add FSharp.Charting NuGet package
- Add reference to `System.Windows.Forms.DataVisualization` and `System.Drawing`
- Create test data using tuples, create line chart, create chart control
- Create and format panel, add the chart control to it, add panel to the form
- What can we do with `FSharp.Charting`? [http://fslab.org/FSharp.Charting/index.html](http://fslab.org/FSharp.Charting/index.html)
  - Area chart to begin with

#### Reading data

- `CSVProvider` from `FSharp.Data` package
- Get example CSV from GitHub
- Import the file with `PreferOptionals` and en-gb `Culture` for dates
- Write tests: post-1978; pre-1950; in between; your birthday
- Calc SPA from date of birth

#### Putting it together

- Use our data in the charting
- Extending the model: asset returns (multiple series)
- Call SPA function