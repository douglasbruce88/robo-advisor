namespace ChartsAndData

module Domain = 
    open System
    
    type Gender = 
        | Male
        | Female
    
    type EmailAddress = 
        | EmailAddres of string
    
    type Person = 
        { Name : string
          Gender : Gender
          DateOfBirth : DateTime
          EmailAddress : EmailAddress option }
    
    type ContributionFrequency = 
        | Monthly
        | Annual
    
    type ContributionSchedule<[<Measure>] 'ccy> = 
        { Amount : decimal<'ccy>
          Frequency : ContributionFrequency }
    
    type PensionPot<[<Measure>] 'ccy> = 
        { Value : decimal<'ccy>
          ValuationDate : DateTime
          ContributionSchedule : ContributionSchedule<'ccy>
          AssetReturn : decimal }
    
    [<Measure>]
    type GBP
    
    [<Measure>]
    type USD
    
    [<Measure>]
    type EUR
    
    let valuePensionPot<[<Measure>] 'ccy> (pensionPot : PensionPot<'ccy>) (valuationDate : DateTime) = 
        let periods = 
            match pensionPot.ContributionSchedule.Frequency with
            | Monthly -> 
                (valuationDate.Year - pensionPot.ValuationDate.Year) * 12 + valuationDate.Month 
                - pensionPot.ValuationDate.Month
            | Annual -> valuationDate.Year - pensionPot.ValuationDate.Year
        
        let assetReturn = 
            match pensionPot.ContributionSchedule.Frequency with
            | Monthly -> pensionPot.AssetReturn / decimal 12
            | Annual -> pensionPot.AssetReturn
        
        let contributions = pensionPot.Value + decimal periods * pensionPot.ContributionSchedule.Amount
        let investmentReturns = contributions * pown (decimal 1 + assetReturn) periods
        (contributions, investmentReturns)
