module Manage.Assertions

open canopy.classic
open canopy.runner.classic
open Manage.Index

let smoke () =
    context "smoke Manage Assertions"
    before (fun _ -> 
        Logout.Flows.logoutOfApplication ()
        Login.Flows.loginToApplication EnvProps.username EnvProps.password
        url Manage.Index.uri 
    )

    "page title should be expected text" &&& fun _ ->
        pageTitle == "Manage your account" 

    "should contain navigation links" &&& fun _ ->
        proflieNav == "Profile"
        passwordNav == "Password"
        twoFactorNav == "Two-factor authentication"
        grantsNav == "Grants"
        diagnosticsNav == "Diagnostics"
        

let full () =
    context "full Manage assertions"
    once (fun _ -> 
        Logout.Flows.logoutOfApplication ()
        Login.Flows.loginToApplication EnvProps.username EnvProps.password
    )
    before(fun _ -> 
        url Manage.Index.uri 
    )

    "page header should be expected text" &&& fun _ ->
        pageHeader == "Change your account settings"

    "should navigate to profile display when profile nav click" &&& fun _ ->
        click proflieNav
        profileHeader == "Profile"

    "profile should display email" &&& fun _ ->
        click proflieNav
        email == EnvProps.username

    "profile should have way to save profile" &&& fun _ ->
        click proflieNav
        profileSave == "Save"

    "profile should display Send verification email when not verified" &&& fun _ ->
        click proflieNav
        sendVerificationEmail == "Send verification email"

    "should navigate to change password when change password nav click" &&& fun _ ->
        click passwordNav
        changePasswordHeader == "Change password"

    "should navigate to two factor when two factor nav click" &&& fun _ ->
        click twoFactorNav
        twoFactorHeader == "Two-factor authentication"

    "two factor should have sub header text" &&& fun _ -> 
        click twoFactorNav
        twoFactorSubHeader == "Authenticator app"

    "two factor should have ability to add" &&& fun _ -> 
        click twoFactorNav
        twoFactorAdd == "Add authenticator app"    

    "should navigate to grants page when grants nav click" &&& fun _ ->
        click grantsNav
        grantsPageTitle == "Client Application Access"

    "should navigate to diagnostics page when diagnostics nav click" &&& fun _ ->
        click diagnosticsNav
        diagnosticsPageTitle == "Authentication cookie"

let edge () =
    context "edge Manage Assertions"

    "on missing password should see set password page when navigating to password nav" &&& todo

let all () =
  smoke()
  full()
  edge()