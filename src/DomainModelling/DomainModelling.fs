namespace DomainModelling

module Domain =
  open System 

  type Gender = Male | Female

  type Person = { Name : string; Gender : Gender }

  [<Measure>] type GBP
  [<Measure>] type USD
  [<Measure>] type EUR
  
  type PensionPot<[<Measure>] 'ccy> = { Value : decimal<'ccy> }