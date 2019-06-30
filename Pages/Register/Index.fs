module Register.Index

open System
open canopy.classic

let uri = EnvProps.baseUri + "/Register"

//selectors
let pageTitle = "#page-title"
let pageTitleText = "Register"
let pageDescription = "#page-description"

let email = "#UserRegistration_Email"
let password = "#UserRegistration_Password"
let confirmPassword = "#UserRegistration_ConfirmPassword"

let registerSumbmit = ".registration-form #submit"

let createTestEmail () = 
    [
        EnvProps.testDomainPrefix;
        "automation-account_";
        Guid.NewGuid().ToString();
        "@";
        EnvProps.testDomain
    ]
    |> String.concat ""

let registerNewAccount emailText passwordText =
    url uri
    email << emailText
    password << passwordText
    confirmPassword << passwordText
    click registerSumbmit


let private random = System.Random()

let private randomCapitalCharacterString len = 
    let chars = "ABCDEFGHIJKLMNOPQRSTUVWUXYZ"
    let charsLen = chars.Length
    let randomChars = [|for i in 0..len -> chars.[random.Next(charsLen)]|]
    String(randomChars)
let private randomLowerCharacterString len =  
    let chars = "abcdefghijklmnopqrstuvwuxyz"
    let charsLen = chars.Length
    let randomChars = [|for i in 0..len -> chars.[random.Next(charsLen)]|]
    String(randomChars)
let private randomNumberString len = 
    let chars = "0123456789"
    let charsLen = chars.Length
    let randomChars = [|for i in 0..len -> chars.[random.Next(charsLen)]|]
    String(randomChars)
let private randomSpecialString len = 
    let chars = "!@#$%";
    let charsLen = chars.Length
    let randomChars = [|for i in 0..len -> chars.[random.Next(charsLen)]|]
    String(randomChars)

let createValidPassword () = 
    [
        randomCapitalCharacterString 2
        randomLowerCharacterString 1
        randomSpecialString 1
        randomNumberString 3
        randomCapitalCharacterString 1
        randomSpecialString 1
    ]
    |> String.concat ""
