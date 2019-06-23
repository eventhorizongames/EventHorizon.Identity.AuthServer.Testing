module Clients.Index

let private selectClient clientId = 
    [".client-list [data-client-id=\""; clientId; "\"]"]
    |> String.concat ""

let uri = EnvProps.baseUri + "/Clients"

//selectors
let pageTitle = "#page-title"
let createNewClient = "#create-new-client"
let clientDispalyElement clientId = 
    [selectClient clientId; " .client-display"] 
    |> String.concat ""
let editClientLink clientId = 
    [selectClient clientId; " .client-edit"] 
    |> String.concat ""
let deleteClientLink clientId = 
    [selectClient clientId; " .client-delete"] 
    |> String.concat ""
