module Register.Actions

open canopy.classic
open canopy.runner.classic
open Register.Index

let smoke () =
    context "smoke Register actions"
    once (fun _ -> 
        Logout.Flow.logoutOfApplication ()
        url Register.Index.uri
    )

    "should be on the New Account Registration page" &&& fun _ ->
        pageTitle == "Register"

    "should give a page description" &&& fun _ ->
        pageDescription == "Create a new account."

let full () =
    context "full Register actions"
    once (fun _ -> 
        Logout.Flow.logoutOfApplication ()
        url Register.Index.uri
    )

    "should be able to register with valid email and password" &&& fun _ ->
        let testEmail = createTestEmail ()
        email << testEmail
        let validPassword = createValidPassword ()
        password << validPassword
        confirmPassword << validPassword
        click registerSumbmit
        url Manage.Index.uri
        Manage.Index.email == testEmail
        Manage.Flow.purgeCurrentAccount


let all () =
  smoke()
  full()