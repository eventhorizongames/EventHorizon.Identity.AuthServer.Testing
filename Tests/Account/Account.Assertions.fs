module Account.Assertions

open System
open canopy.classic
open canopy.runner.classic
open Account.Login

let smoke () =
    context "smoke Account assertions"
    once (fun _ -> 
        url uri
    )

    "should have page title" &&& fun _ ->
        pageTitle == "Login"

let full () =
    context "full Account assertions"
    once (fun _ -> 
        url uri
        pageTitle == "Login"
    )

    "should have an email label" &&& fun _ ->
        usernameLabel == "Email"


let all () =
    smoke()
    full()