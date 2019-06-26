module Manage.Flow

open canopy.classic

let purgeCurrentAccount = 
    // Navigate to Manage account
    url Manage.Index.uri
    // Make sure that the user bing purged is not the EnvProps.username
    Manage.Index.email != EnvProps.username
    // Click on Purge Account
    click Manage.Index.purgeAccount
    // Click on Purge Account Confirm 
    click Manage.Index.purgeAccountConfirm