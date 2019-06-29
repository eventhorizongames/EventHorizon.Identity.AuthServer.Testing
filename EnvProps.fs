module EnvProps

open System.IO
open Newtonsoft.Json


type TestingProps() =
    class
        member val BaseUri : string = "http://localhost:23500" with get, set
        member val Username : string = "test@user.ehz" with get, set
        member val Password : string = "Password1!" with get, set
        member val TestDomain : string = "email.ehzgames.studio" with get, set
        member val ClientId : string = "automation-client" with get, set
        member val RedirectUri : string = "http://localhost:23500" with get, set
    end     

// Load in the values from file
let private propsFile = "./TestingProps.json"
let private testingProps =
    if File.Exists(propsFile) then
        JsonConvert.DeserializeObject<TestingProps>(File.ReadAllText(propsFile))
    else 
        TestingProps()

let private loadedTestingProps = JsonConvert.SerializeObject(testingProps, Formatting.Indented)
// printfn "EnvProps: %s" loadedTestingProps


let baseUri = testingProps.BaseUri
let username = testingProps.Username
let password = testingProps.Password
let testDomain = testingProps.TestDomain
let clientId = testingProps.ClientId
let redirectUri = testingProps.RedirectUri