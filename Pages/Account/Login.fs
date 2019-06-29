module Account.Login

// /Account/Login
let uri = EnvProps.baseUri + "/Account/Login"

//selectors
let pageTitle = ".login-page h1"
let email = "#Email"
let emailLabel = "label[for='Email']"
let emailError = "#Email-error"
let emailErrorByInput = "span[data-valmsg-for='Email']"
let password = "#Password"
let passwordError = "#Password-error"
let passwordErrorByInput = "span[data-valmsg-for='Password']"
let submitButton = "#login-button"
let cancelButton = "#cancel-login-button"
let loginPageTitle = "#login-page-title"
let firstErrorMessage = ".validation-summary-errors li:first"
let registerNewUserLink = "#register-new-user-link"