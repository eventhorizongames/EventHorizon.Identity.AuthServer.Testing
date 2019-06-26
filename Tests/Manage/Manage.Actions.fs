module Manage.Actions

open canopy.classic
open canopy.runner.classic
open Manage.Index

let smoke () =
    context "smoke Manage Actions"
    once (fun _ -> 
        Logout.Flow.logoutOfApplication ()
        Login.Flow.loginToApplication EnvProps.username EnvProps.password
    )
    before(fun _ -> 
        url Manage.Index.uri 
    )

    "clearing profile page first name should set text to empty string" &&& fun _ ->
        click proflieNav
        clear firstName
        firstName == ""
        
    "clearing profile page last name should set text to empty string" &&& fun _ ->
        click proflieNav
        clear lastName
        lastName == ""
        
    "clearing profile page phone number should set text to empty string" &&& fun _ ->
        click proflieNav
        clear phoneNumber
        phoneNumber == ""


    "clearing profile page first name should set text to empty string" &&& fun _ ->
        click passwordNav
        clear currentPassword
        currentPassword == ""
        
    "clearing profile page last name should set text to empty string" &&& fun _ ->
        click passwordNav
        clear newPassword
        newPassword == ""
        
    "clearing profile page phone number should set text to empty string" &&& fun _ ->
        click passwordNav
        clear confirmNewPassword
        confirmNewPassword == ""

let full () =
    context "full Manage Actions"
    once (fun _ -> 
        Logout.Flow.logoutOfApplication ()
        Login.Flow.loginToApplication EnvProps.username EnvProps.password
        resetAccountProfile()
    )
    before(fun _ -> 
        url Manage.Index.uri 
    )
    lastly(fun _ -> 
        resetAccountProfile()
    )
    
    "profile should contain a edit firstname field" &&& fun _ ->
        click proflieNav
        firstName << "First Name"
        firstName == "First Name"
    
    "profile should contain a edit last name field" &&& fun _ ->
        click proflieNav
        lastName << "Last Name"
        lastName == "Last Name"
    
    "profile should contain a edit phone number field" &&& fun _ ->
        click proflieNav
        phoneNumber << "1-123-1234"
        phoneNumber == "1-123-1234"
    
    "profile should successfully update user on save clicked" &&& fun _ ->
        click proflieNav
        firstName << "First Name"
        lastName << "Last Name"
        phoneNumber << "1 123-1234"
        click profileSave
        firstName == "First Name"
        lastName == "Last Name"
        phoneNumber == "1 123-1234"
        profileSuccessMessage == "Your profile has been updated"
    

    "change password should contain a current password field" &&& fun _ ->
        click passwordNav
        currentPassword << "Current Password"
        currentPassword == "Current Password"
    
    "change password should contain a new password field" &&& fun _ ->
        click passwordNav
        newPassword << "NewPassword"
        newPassword == "NewPassword"
    
    "profile should contain a confirm new password field" &&& fun _ ->
        click passwordNav
        confirmNewPassword << "newConfirmPassword" 
        confirmNewPassword == "newConfirmPassword" 



let edge () =
    context "edge Manage Actions"

    "on missing password should see set password page" &&& todo

    "should pruge account when confirmed by a user" &&& fun _ ->
        // Regiser new account
        let email = Register.Index.createTestEmail()
        let password = Register.Index.createValidPassword()
        Register.Index.registerNewAccount email password
        // Navigate to Manage account
        url Manage.Index.uri
        // Validate we are on the Manage uri home page
        Manage.Index.email == email
        // Click on Purge Account
        click purgeAccount
        // Click on Purge Account Confirm 
        click purgeAccountConfirm
        // Validate they are on the Home page
        Home.Index.pageTitle == Home.Index.pageTitleText



let all () =
  smoke()
  full()
  edge()