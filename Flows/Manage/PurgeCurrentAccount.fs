module Manage.Flows

open canopy.classic
open Manage.Index

let purgeCurrentAccount = 
    // Navigate to Manage account
    url uri
    // Make sure that the user bing purged is not the EnvProps.username
    email != EnvProps.username
    // Click on Purge Account
    click purgeAccount
    // Click on Purge Account Confirm 
    click purgeAccountConfirm