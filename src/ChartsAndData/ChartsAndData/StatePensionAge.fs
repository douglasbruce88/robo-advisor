namespace ChartsAndData

module StatePensionAge = 
    open FSharp.Data
    open System
    
    let SPAData = CsvProvider<"StatePensionAge.csv", PreferOptionals=true>.GetSample()
    
    let calcSPA (birthDate : DateTime) = 
        let defaultRetirementAge = 68
        
        let processAgeColumn = 
            function 
            | Some(str : String) -> 
                match Int32.TryParse(str.Substring(0, 2)) with
                | (true, i) -> 
                    let dateWithYearsAdded = birthDate.AddYears(i)
                    match Int32.TryParse(str.Split([| "and " |], StringSplitOptions.None).[0].Substring(0, 2)) with
                    | (true, j) -> dateWithYearsAdded.AddMonths(j)
                    | _ -> dateWithYearsAdded
                | _ -> birthDate.AddYears(defaultRetirementAge)
            | None -> birthDate.AddYears(defaultRetirementAge)
        
        let getDataRow = SPAData.Rows |> Seq.findBack (fun x -> x.``Born After`` > birthDate)
        match getDataRow.``Date State Pension age reached`` with
        | Some date -> date
        | None -> processAgeColumn getDataRow.``Age State Pension age reached``
