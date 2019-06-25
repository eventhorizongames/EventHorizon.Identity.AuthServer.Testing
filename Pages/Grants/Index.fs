module Grants.Index

open canopy.classic

let uri = EnvProps.baseUri + "/Grants"

let pageTitle = "#page-title"
let pageDescription = "#grants-page-description"

let grantClientName clientId = 
    [".grants .grant[data-client-id=\""; clientId; "\"] .clientname"]
    |> String.concat ""
let clientGrantCreatedLabel clientId = 
    [".grants .grant[data-client-id=\""; clientId; "\"] .created .grant-label"]
    |> String.concat ""
let clientGrantCreated clientId = 
    [".grants .grant[data-client-id=\""; clientId; "\"] .created"]
    |> String.concat ""
        
let clientIdentityGrantListLabel clientId =
    [".grants .grant[data-client-id=\""; clientId; "\"] .granttype-identity .grant-label"]
    |> String.concat ""
let clientIdentityGrantedItem (clientId, grantLocation) = 
    nth grantLocation (
        [".grants .grant[data-client-id=\""; clientId; "\"] .granttype-identity li"]
        |> String.concat ""
    )

let clientApiGrantListLabel clientId =
        [".grants .grant[data-client-id=\""; clientId; "\"] .granttype-api .grant-label"]
        |> String.concat ""
let clientApiGranted (clientId, grantLocation) = 
    nth grantLocation (
        [".grants .grant[data-client-id=\""; clientId; "\"] .granttype-api li"]
        |> String.concat ""
    )

let revokeClientAccessButton clientId =
    [".grant[data-client-id=\""; clientId; "\"] .client-revoke button"]
    |> String.concat ""


let revokeAccessToSpecificClient clientId =
    canopy.classic.url uri
    try 
        elementWithText (revokeClientAccessButton clientId) "Revoke" |> ignore;
        printfn "Client found, Revoking Access"
        click (revokeClientAccessButton clientId)
    with   
        | _ -> printfn "No client found"    
