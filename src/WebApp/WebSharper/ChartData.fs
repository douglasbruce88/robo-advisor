namespace WebApp

module ChartData = 
    open Domain
    open System
    open WebSharper.Charting
    open WebSharper
    
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
              
              let value = 
                  date
                  |> valuePensionPot myPot
                  |> fst
                  |> Convert.ToDouble
              (date.ToShortDateString(), value) ]
    
    let returns = 
        [ for i in 0..yearsToRetirement -> 
              let date = myPot.ValuationDate.AddYears(i)
              
              let value = 
                  date
                  |> valuePensionPot myPot
                  |> snd
                  |> Convert.ToDouble
              (date.ToShortDateString(), value) ]
   
    let contributionsChart = Chart.Line(contributions)
    let returnsChart = Chart.Line(returns)

    [<Rpc>]
    let combined() = Chart.Combine([ returnsChart; contributionsChart ])