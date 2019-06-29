module Consent.Assertions

open canopy.classic
open canopy.runner.classic
open Consent.Index

let smoke () =
    context "smoke Consent Assertions"
    once (fun _ -> 
        Logout.Flows.logoutOfApplication ()
        Login.Flows.loginToApplication EnvProps.username EnvProps.password
        Grants.Index.revokeAccessToSpecificClient EnvProps.clientId
        Consent.Index.navigateToConsentPage EnvProps.clientId EnvProps.redirectUri
    )

    "should be on the Consent page" &&& fun _ ->
        pageTitle == EnvProps.clientId + " is requesting your permission"

let full () =
    context "full Consent Assertions"
    once (fun _ -> 
        Logout.Flows.logoutOfApplication ()
        Login.Flows.loginToApplication EnvProps.username EnvProps.password
        Grants.Index.revokeAccessToSpecificClient EnvProps.clientId
        Consent.Index.navigateToConsentPage EnvProps.clientId EnvProps.redirectUri
    )

    "page title should contain information about client" &&& fun _ ->
        pageTitle == EnvProps.clientId + " is requesting your permission"

    "should contain a description" &&& fun _ ->
        pageDescription == "Uncheck the permissions you do not wish to grant."

    "should contain a way to accept permission request" &&& fun _ ->
        yesAllowAccess == "Yes, Allow"

    "should contain a way to not allow permission request" &&& fun _ ->
        noToAccess == "No, Do Not Allow"

    "should contain details about personal information" &&& fun _ ->
        personalInfoHeading == "Personal Information"

    "should contain user identifier section" &&& fun _ ->
        userIdentitiferLabel == "Your user identifier"

    "should require user identifier section" &&& fun _ ->
        userIdentitiferRequiredLabel == "(required)"

    "should default checkbox for user identifier checkbox to selected" &&& fun _ ->
        selected userIdentitiferCheckbox

    "should contain checkbox user profile checkbox" &&& fun _ ->
        userProfileLabel == "User profile"

    "should default checkbox for user profile checkbox to selected" &&& fun _ ->
        selected userProfileCheckbox

    "should contain user profile permission description" &&& fun _ ->
        userProfilePermissionDetails == "Your user profile information (first name, last name, etc.)"

    "should contain details about Applciation requested Access" &&& fun _ ->
        applicationAccessHeading == "Application Access"

    "should contain access scope of API" &&& fun _ ->
        apiApplciationAccessLabel == "My API #1"

    "should default checkbox access scope of API to selected" &&& fun _ ->
        selected apiApplciationAccess

    "should contain access scope of Role" &&& fun _ ->
        rolesApplicationAccessLabel == "Role"

    "should default checkbox access scope of API to selected" &&& fun _ ->
        selected rolesApplicationAccess

    "should contain checkbox for Remember My Decision" &&& fun _ ->
        rememberDecisionLabel == "Remember My Decision"

    "should default checkbox Remember My Decision to selected" &&& fun _ ->
        selected rememberDecisionCheckbox

    "should contain a link to the clients url" &&! fun _ ->
        clientUrl == EnvProps.clientId

    "should contain a link to the clients url" &&! fun _ ->
        // Note that the href for this client will be ssl
        clientUrlByHref EnvProps.baseUri == EnvProps.clientId


let all () =
  smoke()
  full()