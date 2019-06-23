module Clients.Edit

let clientsEditUri clientId = EnvProps.baseUri + "/Clients/Edit/" + clientId

//selectors
let pageTitle = "#client-edit-page-title"