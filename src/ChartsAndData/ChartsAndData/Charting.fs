namespace ChartsAndData

module Charting = 
    open Domain
    open FSharp.Charting
    open FSharp.Charting.ChartTypes
    open System
    open System.Windows.Forms
    
    let me = 
        { Name = "Doug"
          Gender = Male
          DateOfBirth = DateTime(1988, 01, 29)
          EmailAddress = None }
    
    let schedule = 
        { Amount = 500m<GBP>
          Frequency = Monthly }
    
    let myPot = 
        { Value = 10000m<GBP>
          ValuationDate = DateTime(2016, 06, 30)
          ContributionSchedule = schedule
          AssetReturn = decimal 0.05 }
    
    let yearsToRetirement = 25
    
    let contributions = 
        [ for i in 0..yearsToRetirement -> 
              let date = myPot.ValuationDate.AddYears(i)
              (date, fst (valuePensionPot myPot date)) ]
    
    let returns = 
        [ for i in 0..yearsToRetirement -> 
              let date = myPot.ValuationDate.AddYears(i)
              (date, snd (valuePensionPot myPot date)) ]
    
    let contributionsChart = Chart.Area(contributions, Name = "Contributions")
    let returnsChart = Chart.Area(returns, Name = "Asset Returns")
    let combined = Chart.Combine([ returnsChart; contributionsChart ])
    let chartControl = new ChartControl(combined.WithLegend(), Dock = DockStyle.Fill, Name = "Valuation")
