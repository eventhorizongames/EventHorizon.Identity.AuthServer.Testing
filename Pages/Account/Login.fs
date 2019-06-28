module Account.Login

// /Account/Login
let uri = EnvProps.baseUri + "/Account/Login"

//selectors
let pageTitle = ".login-page h1"
let username = "#Username"
let usernameLabel = "label[for='Username']"
let usernameError = "#Username-error"
let usernameErrorByInput = "span[data-valmsg-for='Username']"
let password = "#Password"
let passwordError = "#Password-error"
let passwordErrorByInput = "span[data-valmsg-for='Password']"
let submitButton = "#login-button"
let cancelButton = "#cancel-login-button"
let loginPageTitle = "#login-page-title"
let firstErrorMessage = ".validation-summary-errors li:first"
let registerNewUserLink = "#register-new-user-link"