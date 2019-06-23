module Manage.Index

open canopy.classic

let uri = EnvProps.baseUri + "/Manage"

// Genearl Selectors
let pageTitle = "#page-title"
let pageHeader = "#page-header"

// Navigation Selectors
let proflieNav = "#open-profile"
let passwordNav = "#open-password"
let twoFactorNav = "#open-two-factor"
let grantsNav = "#open-grants"
let diagnosticsNav = "#open-diagnostics"

// Profile Selectors
let profileHeader = "#profile-header"
let email = ".profile #Username"
let sendVerificationEmail = ".profile #send-verification-email"
let firstName = ".profile #Profile_FirstName"
let lastName = ".profile #Profile_LastName"
let phoneNumber = ".profile #Profile_PhoneNumber"
let profileSave = ".profile #save-profile"
let profileSuccessMessage = ".status-message"

// Password Selectors
let changePasswordHeader = "#change-password-header"
let currentPassword = "#change-password-form #OldPassword"
let newPassword = "#change-password-form #NewPassword"
let confirmNewPassword = "#change-password-form #ConfirmPassword"

// Two-Factor Authentication Selectors
let twoFactorHeader = "#two-factor-header"
let twoFactorSubHeader = "#two-factor-sub-header"
let twoFactorAdd = "#add-two-factor-app"

// Grants Selectors
let grantsPageTitle = "#page-title"

// Diagnostics Selectors
let diagnosticsPageTitle = "#page-title"


let resetAccountProfile () =
    // Reset the logged in account
    url uri 
    click proflieNav
    firstName << ""
    lastName << ""
    phoneNumber << ""
    click profileSave
    