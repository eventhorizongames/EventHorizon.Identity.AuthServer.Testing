module Clients.Create

open canopy.classic

let uri = EnvProps.baseUri + "/Clients/Create"

//selectors
let clientId = "#Client_Id"
let clientName = "#Client_Name"
let createClient = "#create-client"

let createNewClient clientId clientName =
    url uri
    clientId << clientId
    clientName << clientName
    click createClient