module Grants.Actions

open canopy.classic
open canopy.runner.classic
open Grants.Index

let smoke () =
    context "smoke Grants actions"
    before (fun _ -> 
        Consent.Index.acceptConsentToClient "automation-client" "http://localhost:23500/"
        url Grants.Index.uri
    )
    lastly (fun _ -> 
        Grants.Index.revokeAccessToSpecificClient "automation-client"
    )

    "should successfully revoke client access" &&& fun _ ->
        displayed (grantClientName "automation-client")
        click (revokeClientAccessButton "automation-client")
        notDisplayed (grantClientName "automation-client")

let full () =
    context "full Grants actions"
    before (fun _ -> 
        Grants.Index.revokeAccessToSpecificClient "automation-client"
        url Grants.Index.uri
    )
    lastly (fun _ -> 
        Grants.Index.revokeAccessToSpecificClient "automation-client"
    )

    "should show accepted consent to request" &&& fun _ ->
        notDisplayed (grantClientName "automation-client")
        Consent.Index.acceptConsentToClient "automation-client" "http://localhost:23500/"
        url Grants.Index.uri
        displayed (grantClientName "automation-client")
        click (revokeClientAccessButton "automation-client")
        notDisplayed (grantClientName "automation-client")

let all () =
    smoke()
    full()