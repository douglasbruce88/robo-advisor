namespace WebApp

module StatePensionAge = 
    open FSharp.Data
    open System
    
    let SPAData = 
        CsvProvider<"StatePensionAge.csv", PreferOptionals=true, Culture="en-gb">.GetSample()
    
    let calcSPA (birthDate : DateTime) = 
        let defaultRetirementAge = 68
        
        let processAgeColumn = 
            function 
            | Some(str : String) -> 
                match Int32.TryParse(str.Substring(0, 2)) with
                | (true, i) -> 
                    let dateWithYearsAdded = birthDate.AddYears(i)
                    let split = str.Split([| " and " |], StringSplitOptions.None)
                    match split.Length with
                    | 1 -> dateWithYearsAdded
                    | _ -> dateWithYearsAdded.AddMonths(Int32.Parse(split.[1].Substring(0, 2)))
                | _ -> birthDate.AddYears(defaultRetirementAge)
            | None -> birthDate.AddYears(defaultRetirementAge)
        
        let getDataRow = SPAData.Rows |> Seq.findBack (fun x -> birthDate > x.``Born After``)
        match getDataRow.``Date State Pension age reached`` with
        | Some date -> date
        | None -> processAgeColumn getDataRow.``Age State Pension age reached``
