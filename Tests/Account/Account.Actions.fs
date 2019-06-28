module Account.Actions

open canopy.classic
open canopy.runner.classic

let smoke () =
    context "smoke Account.Login actions"
    before (fun _ -> 
        Logout.Flows.logoutOfApplication()
        url Account.Login.uri 
    )

    "submit form" &&& fun _ ->
        Account.Login.username << EnvProps.username
        Account.Login.password << EnvProps.password
        click Account.Login.submitButton
        Home.Index.pageTitle == "Welcome to EventHorizon Game Studio Identity"

let full () =
    context "full Account.Login actions"
    before (fun _ -> 
        Logout.Flows.logoutOfApplication()
        url Account.Login.uri 
    )

    "should land on home page when login is successful" &&& fun _ -> 
        Login.Flows.loginToApplication EnvProps.username EnvProps.password
        Home.Index.pageTitle == "Welcome to EventHorizon Game Studio Identity"

    "should show error message on login page when username is invalid email" &&& fun _ -> 
        Login.Flows.loginToApplication "invalid username" EnvProps.password
        Account.Login.usernameError == "The Email field is not a valid e-mail address."
        
    "should show error message on login page when password is invalid" &&& fun _ -> 
        Login.Flows.loginToApplication EnvProps.username "invalid password"
        Account.Login.firstErrorMessage == "Invalid username or password"
        
    "should show password error message when password is empty" &&& fun _ -> 
        Login.Flows.loginToApplication EnvProps.username ""
        Account.Login.passwordError == "The Password field is required."
        
    "should show Email error message when username is empty" &&& fun _ -> 
        Login.Flows.loginToApplication "" "not empty"
        Account.Login.usernameError == "The Email field is required."
        
    "should show Email and Password error message when both are empty" &&& fun _ -> 
        Login.Flows.loginToApplication "" ""
        Account.Login.usernameErrorByInput == "The Email field is required."
        Account.Login.passwordErrorByInput == "The Password field is required."
        
    "should navigate to Home page on cancel button click" &&& fun _ -> 
        click Account.Login.cancelButton
        Home.Index.pageTitle == "Welcome to EventHorizon Game Studio Identity"
        
    "should navigate to Registration page on register as new user link click" &&& fun _ -> 
        click Account.Login.registerNewUserLink
        Register.Index.pageTitle == Register.Index.pageTitleText

    "clearing #username sets text to new empty string via IWebElement" &&& fun _ ->
        element Account.Login.username |> clear
        Account.Login.username == ""

let all () =
    smoke()
    full()