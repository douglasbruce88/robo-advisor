[<FunScript.JS>]
module Page

open FunScript
open FunScript.TypeScript

let hello () =
  Globals.window.alert("Hello world!")

// Allows writing jq?name for element access
let jq(selector : string) = Globals.Dollar.Invoke selector
let (?) jq name = jq("#" + name)

let main() = 
  jq?helloWorld.click(fun _ -> hello() :> obj)

do Runtime.Run(directory="Web")