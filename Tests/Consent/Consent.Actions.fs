module Consent.Actions

open canopy.classic
open canopy.runner.classic
open Consent.Index

let smoke () =
    context "smoke Consent actions"
    once (fun _ -> 
        Logout.Flows.logoutOfApplication ()
        Login.Flows.loginToApplication EnvProps.username EnvProps.password
        Grants.Index.revokeAccessToSpecificClient EnvProps.clientId
    )
    before(fun _ -> 
        let theurl = Consent.Index.createConsentUrl EnvProps.clientId EnvProps.redirectUri;
        System.Console.WriteLine(theurl);
        url (Consent.Index.createConsentUrl EnvProps.clientId EnvProps.redirectUri)
    )

    "should be on the Consent page" &&& fun _ ->
        pageTitle == EnvProps.clientId + " is requesting your permission"

let full () =
    context "full Consent actions"
    once (fun _ -> 
        Logout.Flows.logoutOfApplication ()
        Login.Flows.loginToApplication EnvProps.username EnvProps.password
        Grants.Index.revokeAccessToSpecificClient EnvProps.clientId
    )
    before(fun _ -> 
        System.Console.WriteLine(Consent.Index.createConsentUrl EnvProps.clientId EnvProps.redirectUri);
        url (Consent.Index.createConsentUrl EnvProps.clientId EnvProps.redirectUri)
        pageTitle == EnvProps.clientId + " is requesting your permission"
    )

    "should be on the Consent page" &&& fun _ ->
        pageTitle == EnvProps.clientId + " is requesting your permission"

    "should be able to accept " &&& fun _ ->
        pageTitle == EnvProps.clientId + " is requesting your permission"
        click yesAllowAccess

let all () =
  smoke()
  full()