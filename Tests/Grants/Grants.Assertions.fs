module Grants.Assertions

open System
open canopy.classic
open canopy.runner.classic
open Grants.Index

let smoke () =
    context "smoke Grants assertions"
    once (fun _ -> 
        Consent.Index.acceptConsentToClient EnvProps.clientId EnvProps.redirectUri
    )
    before(fun _ -> 
        url Grants.Index.uri
    )

    "should have page title" &&& fun _ ->
        pageTitle == "Client Application Access"

let full () =
    context "full Grants assertions"
    once (fun _ -> 
        Grants.Index.revokeAccessToSpecificClient EnvProps.clientId
        Consent.Index.acceptConsentToClient EnvProps.clientId EnvProps.redirectUri
    )
    before(fun _ -> 
        url Grants.Index.uri
        pageTitle == "Client Application Access"
    )

    "should have a page description" &&& fun _ ->
        pageDescription == "Below is the list of applications you have given access to and the names of the resources they have access to."

    "should show client name" &&& fun _ ->
        grantClientName EnvProps.clientId == EnvProps.clientId
        
    "should show label for client created" &&& fun _ ->
        clientGrantCreatedLabel (EnvProps.clientId) == "Created:"
        
    "should show client created in YYYY-MM-DD format" &&& fun _ ->
        let now = DateTime.UtcNow
        let expected = now.Year.ToString() + "-" + now.Month.ToString("D2") + "-" + now.Day.ToString("D2")
        contains expected (read (clientGrantCreated (EnvProps.clientId)))
        

    "should show label for Identity Grants" &&& fun _ ->
        clientIdentityGrantListLabel (EnvProps.clientId) == "Identity Grants"

    "should show name for Identity Grant item 1" &&& fun _ ->
        read (clientIdentityGrantedItem (EnvProps.clientId, 0)) == "Your user identifier"

    "should show name for Identity Grant item 2" &&& fun _ ->
        read (clientIdentityGrantedItem (EnvProps.clientId, 1)) == "User profile"
        
        
    "should show label for API Grants" &&& fun _ ->
        clientApiGrantListLabel (EnvProps.clientId) == "API Grants"

    "should show name for Identity Grant item 1" &&& fun _ ->
        read (clientApiGranted (EnvProps.clientId, 0)) == "api1"

    "should show name for Identity Grant item 2" &&& fun _ ->
        read (clientApiGranted (EnvProps.clientId, 1)) == "roles"



let all () =
    smoke()
    full()