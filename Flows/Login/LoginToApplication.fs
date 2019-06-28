module Login.Flows

open canopy.classic

let loginToApplication username password =
    url Account.Login.uri
    Account.Login.username << username
    Account.Login.password << password
    click Account.Login.submitButton