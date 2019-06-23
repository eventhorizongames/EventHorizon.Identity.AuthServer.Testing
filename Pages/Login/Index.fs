module Login.Index

let uri = EnvProps.baseUri + "/Account/Login"

//selectors
let username = "#Username"
let password = "#Password"
let submitButton = "#login-button"
let cancelButton = "#cancel-login-button"
let loginPageTitle = "#login-page-title"
let firstErrorMessage = ".validation-summary-errors li:first"
let registerNewUserLink = "#register-new-user-link"