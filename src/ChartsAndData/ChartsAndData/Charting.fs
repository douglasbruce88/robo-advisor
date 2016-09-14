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
          ContributionSchedule = schedule }
    
    let valueMyPot = 
        [ for i in 1..50 -> 
              let date = myPot.ValuationDate.AddYears(i)
              (date, valuePensionPot myPot date) ]
    
    let testChart = Chart.Area(valueMyPot)
    let chartControl = new ChartControl(testChart, Dock = DockStyle.Fill, Name = "Valuation")
