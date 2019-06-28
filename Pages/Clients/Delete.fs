module Clients.Delete

let clientDeleteUri clientId = EnvProps.baseUri + "/Clients/Delete/" + clientId

//selectors
let pageTitle = "#page-title"
let pageDescription = "#page-description"
let confirmDelete = "#confirm"
let cancelDelete = "#cancel"