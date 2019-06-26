module Login.Actions

open canopy.classic
open canopy.runner.classic
open Login.Index

let smoke () =
    context "smoke Login actions"
    before (fun _ -> 
        Logout.Flow.logoutOfApplication()
        url Login.Index.uri 
    )

    "submit form" &&& fun _ ->
        username << EnvProps.username
        password << EnvProps.password
        click submitButton
        Home.Index.pageTitle == "Welcome to EventHorizon Game Studio Identity"

let full () =
    context "full Login actions"
    before (fun _ -> 
        Logout.Flow.logoutOfApplication()
        url Login.Index.uri 
    )

    "should land on home page when login is successful" &&& fun _ -> 
        Login.Flow.loginToApplication EnvProps.username EnvProps.password
        Home.Index.pageTitle == "Welcome to EventHorizon Game Studio Identity"

    "should show error message on login page when username is invalid login" &&& fun _ -> 
        Login.Flow.loginToApplication "invalid username" EnvProps.password
        firstErrorMessage == "Invalid username or password"
        
    "should show error message on login page when password is invalid" &&& fun _ -> 
        Login.Flow.loginToApplication EnvProps.username "invalid password"
        firstErrorMessage == "Invalid username or password"
        
    "should show password error message when password is empty" &&& fun _ -> 
        Login.Flow.loginToApplication EnvProps.username ""
        firstErrorMessage == "The Password field is required."
        
    "should show Email error message when username is empty" &&& fun _ -> 
        Login.Flow.loginToApplication "" "not empty"
        firstErrorMessage == "The Email field is required."
        
    "should navigate to Home page on cancel button click" &&& fun _ -> 
        click cancelButton
        Home.Index.pageTitle == "Welcome to EventHorizon Game Studio Identity"
        
    "should navigate to Registration page on register as new user link click" &&& fun _ -> 
        click registerNewUserLink
        Register.Index.pageTitle == Register.Index.pageTitleText

    "clearing #username sets text to new empty string via IWebElement" &&& fun _ ->
        element username |> clear
        username == ""

let all () =
  smoke()
  full()