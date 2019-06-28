module Register.Assertions

open canopy.classic
open canopy.runner.classic
open Register.Index

let smoke () =
    context "smoke Register Assertions"
    once (fun _ -> 
        Logout.Flows.logoutOfApplication ()
        url Register.Index.uri
    )

    "should be on the Registration page" &&& todo

let full () =
    context "full Register Assertions"
    once (fun _ -> 
        Logout.Flows.logoutOfApplication ()
        url Register.Index.uri
    )

    "should be on the Registration page" &&& todo


let all () =
  smoke()
  full()