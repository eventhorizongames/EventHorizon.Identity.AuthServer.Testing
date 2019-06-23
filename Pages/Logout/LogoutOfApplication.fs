module Logout.Flow

open canopy.classic
open Logout.Index

let logoutOfApplication () =
    url Logout.Index.uri
    try 
        elementWithText submitButton "Yes" |> ignore;
        printfn "User was found, logging out."
        click submitButton
    with
        | _ -> printfn "No user logged in."