module Consent.Index

open System.Web
open canopy.classic

// https://localhost:23501/connect/authorize?client_id=overlay-client&redirect_uri=&response_type=code&scope=openid%20profile%20api1%20roles&state=fe737009777944db9de80baf370105a1&code_challenge=_ubt4YbQ-7qU1tho4STnaDAG6RcRbKphIt3SH4mwq5c&code_challenge_method=S256

let private authroizeUrl = EnvProps.baseUri + "/connect/authorize"
let private responseType = "code"
let private scope = "openid profile api1 roles"
let private state = "fe737009777944db9de80baf370105a1"
let private codeChallenge = "_ubt4YbQ-7qU1tho4STnaDAG6RcRbKphIt3SH4mwq5c"
let private codeChallengeMethod = "S256"

let createConsentUrl clientId redirectUri = 
    [
        authroizeUrl; 
        "?client_id="; clientId;
        "&redirect_uri="; redirectUri;
        "&response_type="; responseType;
        "&scope="; HttpUtility.HtmlDecode scope;
        "&state="; state;
        "&code_challenge="; codeChallenge;
        "&code_challenge_method="; codeChallengeMethod;
    ] 
    |> String.concat ""

let navigateToConsentPage clientId redirectUri =
    createConsentUrl clientId redirectUri 
    |> fun consentUrl -> 
        System.Console.WriteLine consentUrl
        url consentUrl


let pageTitle = ".page-title"
let pageDescription = ".consent-page-description"
let yesAllowAccess = ".consent-form #yes"
let noToAccess = ".consent-form #no"

let personalInfoHeading = ".personal-info .panel-heading"
let userIdentitiferLabel = "label:has(#scopes_openid)"
let userIdentitiferCheckbox = "#scopes_openid"
let userIdentitiferRequiredLabel = "li:has(label:has(#scopes_openid)) span em"
let userProfileLabel = "label:has(#scopes_profile)"
let userProfileCheckbox = "#scopes_profile"
let userProfilePermissionDetails = ".consent-description [for=\"scopes_profile\"]"

let applicationAccessHeading = ".application-access .panel-heading"
let apiApplciationAccess = "#scopes_api1"
let apiApplciationAccessLabel = "label:has(#scopes_api1)"
let rolesApplicationAccess = "#scopes_roles"
let rolesApplicationAccessLabel = "label:has(#scopes_roles)"

let rememberDecisionCheckbox = "#RememberConsent"
let rememberDecisionLabel = "label:has(#RememberConsent)"

let clientUrl = "#client-url"
let clientUrlByHref href = "#client-url[href=\"" + href + "\"]"

let acceptConsentToClient clientId redirectUrl =
    navigateToConsentPage clientId redirectUrl
    try 
        elementWithText yesAllowAccess "Yes" |> ignore;
        printfn "Client Consent page found, Allowing Access."
        click yesAllowAccess
    with   
        | _ -> printfn "Client Consent could have already been given..."   