module Consent.Actions

open canopy.classic
open canopy.runner.classic
open Consent.Index

let smoke () =
    context "smoke Consent actions"
    once (fun _ -> 
        Logout.Flow.logoutOfApplication ()
        Login.Flow.loginToApplication EnvProps.username EnvProps.password
        Grants.Index.revokeAccessToSpecificClient "automation-client"
    )
    before(fun _ -> 
        let theurl = Consent.Index.createConcentUrl "automation-client" "http://localhost:23500/";
        System.Console.WriteLine(theurl)
        url (Consent.Index.createConcentUrl "automation-client" "http://localhost:23500/")
    )

    "should be on the Consent page" &&& fun _ ->
        pageTitle == "automation-client is requesting your permission"

let full () =
    context "full Consent actions"
    once (fun _ -> 
        Logout.Flow.logoutOfApplication ()
        Login.Flow.loginToApplication EnvProps.username EnvProps.password
        Grants.Index.revokeAccessToSpecificClient "automation-client"
    )
    before(fun _ -> 
        url (Consent.Index.createConcentUrl "automation-client" "http://localhost:23500/")
        pageTitle == "automation-client is requesting your permission"
    )

    "should be on the Consent page" &&& fun _ ->
        pageTitle == "automation-client is requesting your permission"

    "should be able to accept " &&& fun _ ->
        pageTitle == "automation-client is requesting your permission"
        click yesAllowAccess

let all () =
  smoke()
  full()