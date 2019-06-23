module Login.Flow

open canopy.classic

let loginToApplication username password =
    url Login.Index.uri
    Login.Index.username << username
    Login.Index.password << password
    click Login.Index.submitButton