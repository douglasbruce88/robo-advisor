# Building our web application

- Running the application
  - WebSharper: closer to the 'old' style of .NET development: VS, ASP.NET, etc. There are oddities with bringing data across to the JS, though (i.e. `<RPC>`)
  - Fable: much closer to the Javascript itself
  - Funscript
- Hooking up our Charts
  - WebSharper has highcharts module or its built-in Charting package as part of `UINext`. The latter tries to more resemble `FSharp.Charting`. We need a client-server app in order to be able to process our computations
  - Fable has D3 bindings
- DevOps
  - NuGet; MSBuild; Visual Studio or Paket; Fake; VS Code/Atom
  - CI (TeamCity), CD (Octopus)
  - Azure, Infrastructure as codeB

## Walkthrough of example

- Download my basic example from **???**
- Look at each file
  - `Main.fs`: simple call to `Client`
  - `Client.fs`: annotated with `[<JavaScript>]`. Gets chart, renders in a `div`
  - `Server.fs`: annotated with `[<RPC>]` simple wrapper for our existing code
  - `ChartData.fs`: almost identical to previous code but uses `WebSharper.Charting`
- Improve our charts! (**TODO**)
  - Formatting
  - Labelling
  - Buttons to change 'levers'

#### D.I.Y

- Download WebSharper templates
- Create new UINext client/server template
- Run `Setup.fsx`
- Add our existing files (`Domain.fs`, `StatePensionAge.fs` and `ChartData.fs`) from **???**
- Change charting to `WebSharper.Charting` (download NuGet package)
