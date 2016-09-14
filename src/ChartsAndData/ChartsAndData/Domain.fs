namespace ChartsAndData

module Domain =
  open System 

  type Gender = Male | Female

  type EmailAddress = EmailAddres of string

  type Person = { 
      Name : string
      Gender : Gender
      DateOfBirth : DateTime
      EmailAddress : EmailAddress option }

  type ContributionFrequency = Monthly | Annual

  type ContributionSchedule<[<Measure>] 'ccy> = {
      Amount : decimal<'ccy>
      Frequency : ContributionFrequency }
  
  type PensionPot<[<Measure>] 'ccy> = { 
      Value : decimal<'ccy>; 
      ValuationDate : DateTime; 
      ContributionSchedule: ContributionSchedule<'ccy> }

  [<Measure>] type GBP
  [<Measure>] type USD
  [<Measure>] type EUR

  let valuePensionPot<[<Measure>] 'ccy> (pensionPot : PensionPot<'ccy>) (valuationDate: DateTime) = 
     match pensionPot.ContributionSchedule.Frequency with 
     | Monthly ->
        let monthsInFuture = (valuationDate.Year - pensionPot.ValuationDate.Year) * 12 + valuationDate.Month - pensionPot.ValuationDate.Month
        pensionPot.Value + decimal monthsInFuture * pensionPot.ContributionSchedule.Amount
     | Annual ->
        let yearsInFuture = valuationDate.Year - pensionPot.ValuationDate.Year
        pensionPot.Value + decimal yearsInFuture * pensionPot.ContributionSchedule.Amount