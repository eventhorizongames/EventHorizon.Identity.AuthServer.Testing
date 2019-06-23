module Clients.Assertions

open canopy.classic
open canopy.runner.classic
open Clients.Index

let smoke () =
    context "smoke Clients.Index Assertions"
    before (fun _ -> 
        Logout.Flow.logoutOfApplication()
        Login.Flow.loginToApplication EnvProps.username EnvProps.password
        url Clients.Index.uri 
    )

    "page title should be Clients" &&& fun _ ->
        pageTitle == "Clients" 
        

let full () =
    context "full Clients.Index assertions"
    before (fun _ -> 
        Logout.Flow.logoutOfApplication()
        Login.Flow.loginToApplication EnvProps.username EnvProps.password
        url Clients.Index.uri 
    )

    "should have a way to create new clients" &&& fun _ ->
        pageTitle == "Clients"
        createNewClient == "Create"
        



let all () =
  smoke()
  full()