module Grants.Assertions

open System
open canopy.classic
open canopy.runner.classic
open Grants.Index

let smoke () =
    context "smoke Grants assertions"
    once (fun _ -> 
        Consent.Index.acceptConsentToClient "automation-client" "http://localhost:23500/"
    )
    before(fun _ -> 
        url Grants.Index.uri
    )

    "should have page title" &&& fun _ ->
        pageTitle == "Client Application Access"

let full () =
    context "full Grants assertions"
    once (fun _ -> 
        Grants.Index.revokeAccessToSpecificClient "automation-client"
        Consent.Index.acceptConsentToClient "automation-client" "http://localhost:23500/"
    )
    before(fun _ -> 
        url Grants.Index.uri
        pageTitle == "Client Application Access"
    )

    "should have a page description" &&& fun _ ->
        pageDescription == "Below is the list of applications you have given access to and the names of the resources they have access to."

    "should show client name" &&& fun _ ->
        grantClientName "automation-client" == "automation-client"
        
    "should show label for client created" &&& fun _ ->
        clientGrantCreatedLabel ("automation-client") == "Created:"
        
    "should show client created in YYYY-MM-DD format" &&& fun _ ->
        let now = DateTime.UtcNow
        let expected = now.Year.ToString() + "-" + now.Month.ToString("D2") + "-" + now.Day.ToString("D2")
        contains expected (read (clientGrantCreated ("automation-client")))
        

    "should show label for Identity Grants" &&& fun _ ->
        clientIdentityGrantListLabel ("automation-client") == "Identity Grants"

    "should show name for Identity Grant item 1" &&& fun _ ->
        read (clientIdentityGrantedItem ("automation-client", 0)) == "Your user identifier"

    "should show name for Identity Grant item 2" &&& fun _ ->
        read (clientIdentityGrantedItem ("automation-client", 1)) == "User profile"
        
        
    "should show label for API Grants" &&& fun _ ->
        clientApiGrantListLabel ("automation-client") == "API Grants"

    "should show name for Identity Grant item 1" &&& fun _ ->
        read (clientApiGranted ("automation-client", 0)) == "api1"

    "should show name for Identity Grant item 2" &&& fun _ ->
        read (clientApiGranted ("automation-client", 1)) == "roles"



let all () =
    smoke()
    full()