module Grants.Index

open canopy.classic

let url = EnvProps.baseUri + "/Grants"

let revokeClientAccessButton clientId =
    [".grant[data-client-id=\""; clientId; "\"] .client-revoke button"]
    |> String.concat ""


let revokeAccessToSpecificClient clientId =
    canopy.classic.url url
    try 
        elementWithText (revokeClientAccessButton clientId) "Revoke" |> ignore;
        printfn "Client found, Revoking Access"
        click (revokeClientAccessButton clientId)
    with   
        | _ -> printfn "No client found"    