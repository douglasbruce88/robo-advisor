namespace ChartsAndData.Tests

module StatePensionAgeTests = 
    open NUnit.Framework
    open Swensen.Unquote
    open ChartsAndData.StatePensionAge
    open System
    
    let testCaseSource = 
       [ DateTime(1988, 01, 29), DateTime(2056, 01, 29)
         DateTime(1954, 05, 07), DateTime(2020, 01, 06)
         DateTime(1960, 07, 09), DateTime(2026, 11, 09)
       ] |> List.map (fun (input, result) -> TestCaseData(input, result))

    [<Test>]
    [<TestCaseSource("testCaseSource")>]
    let ``SPA Calculation is correct``(input: DateTime, expected: DateTime) = 
        let actual = input |> calcSPA 
        actual =! expected
