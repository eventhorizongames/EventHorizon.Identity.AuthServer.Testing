module Grants.Actions

open canopy.classic
open canopy.runner.classic
open Grants.Index

let smoke () =
    context "smoke Grants actions"
    before (fun _ -> 
        Consent.Index.acceptConsentToClient EnvProps.clientId EnvProps.redirectUri
        url Grants.Index.uri
    )
    lastly (fun _ -> 
        Grants.Index.revokeAccessToSpecificClient EnvProps.clientId
    )

    "should successfully revoke client access" &&& fun _ ->
        displayed (grantClientName EnvProps.clientId)
        click (revokeClientAccessButton EnvProps.clientId)
        notDisplayed (grantClientName EnvProps.clientId)

let full () =
    context "full Grants actions"
    before (fun _ -> 
        Grants.Index.revokeAccessToSpecificClient EnvProps.clientId
        url Grants.Index.uri
    )
    lastly (fun _ -> 
        Grants.Index.revokeAccessToSpecificClient EnvProps.clientId
    )

    "should show accepted consent to request" &&& fun _ ->
        notDisplayed (grantClientName EnvProps.clientId)
        Consent.Index.acceptConsentToClient EnvProps.clientId EnvProps.redirectUri
        url Grants.Index.uri
        displayed (grantClientName EnvProps.clientId)
        click (revokeClientAccessButton EnvProps.clientId)
        notDisplayed (grantClientName EnvProps.clientId)

let all () =
    smoke()
    full()