  #load "DomainModelling.fs"
  open DomainModelling.Domain
  open System
  
  let me = { Name = "Doug"; Gender = Male; DateOfBirth = DateTime(1988, 01, 29) }

  let schedule = { Amount = 500m<GBP>; Frequency = Monthly} 

  let myPot = { Value = 10000m<GBP>; ValuationDate = DateTime(2016, 06, 30); ContributionSchedule = schedule }

  let valueMyPensionPot = valuePensionPot myPot

  valueMyPensionPot (DateTime(2017, 06, 30));;
  valueMyPensionPot (DateTime(2026, 06, 30));;
  valueMyPensionPot (DateTime(2046, 06, 30))
