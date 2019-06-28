module Logout.Flows

open canopy.classic

let logoutOfApplication () =
    url Account.Logout.uri
    try 
        elementWithText Account.Logout.submitButton "Yes" |> ignore;
        printfn "User was found, logging out."
        click Account.Logout.submitButton
    with
        | _ -> printfn "No user logged in."