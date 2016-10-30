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
  - Azure, Infrastructure as code
