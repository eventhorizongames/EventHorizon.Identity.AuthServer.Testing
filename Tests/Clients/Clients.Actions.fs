module Clients.Actions

open canopy.classic
open canopy.runner.classic
open Clients.Index

let smoke () =
    context "smoke Clients Index actions"
    once (fun _ -> 
        Logout.Flows.logoutOfApplication ()
        Login.Flows.loginToApplication EnvProps.username EnvProps.password
    )
    before(fun _ -> 
        url Clients.Index.uri 
    )

    "should be on the Clients home page" &&& fun _ ->
        pageTitle == "Clients"

let full () =
    context "full Login Index actions"
    once (fun _ -> 
        Logout.Flows.logoutOfApplication ()
        Login.Flows.loginToApplication EnvProps.username EnvProps.password
    )
    before(fun _ -> 
        url Clients.Index.uri 
        pageTitle == "Clients"
    )

    let createNewClient clientId clientName =
        url Clients.Create.uri
        Clients.Create.clientId << clientId
        Clients.Create.clientName << clientName
        click Clients.Create.createClient

    let deleteClient clientId =
        Clients.Delete.clientDeleteUri clientId
        |> url
        click Clients.Delete.confirmDelete
        pageTitle == "Clients"

    "should create new client and list on index page" &&& fun _ ->
        // Create new client
        let guid = System.Guid.NewGuid().ToString()
        let clientIdGuid =  "client-id-" + guid
        let clientNameGuid = "Client Name " + guid
        createNewClient clientIdGuid clientNameGuid
        // Validate on Clients Index Page after submit
        pageTitle == "Clients"
        // Make sure Created Clients is listed on page
        clientDispalyElement clientIdGuid == clientNameGuid + " (" + clientIdGuid + ")"
        deleteClient clientIdGuid

    "should new create clients with Edit link" &&&  fun _ ->
        // Create new client
        let guid = System.Guid.NewGuid().ToString()
        let clientIdGuid =  "client-id-" + guid
        let clientNameGuid = "Client Name " + guid
        createNewClient clientIdGuid clientNameGuid
        // Validate on Clients Index Page after submit
        pageTitle == "Clients"
        // Make sure Created Clients is listed on page
        editClientLink clientIdGuid == "Edit"
        deleteClient clientIdGuid

    "should new create clients with Delete link" &&& fun _ ->
        // Create new client
        let guid = System.Guid.NewGuid().ToString()
        let clientIdGuid =  "client-id-" + guid
        let clientNameGuid = "Client Name " + guid
        createNewClient clientIdGuid clientNameGuid
        // Validate on Clients Index Page after submit
        pageTitle == "Clients"
        // Make sure Created Clients is listed on page
        deleteClientLink clientIdGuid == "Delete"
        deleteClient clientIdGuid

    "should delete clients when Delete link is clicked" &&& fun _ ->
        // Create new client
        let guid = System.Guid.NewGuid().ToString()
        let clientIdGuid =  "client-id-" + guid
        let clientNameGuid = "Client Name " + guid
        createNewClient clientIdGuid clientNameGuid
        // Validate on Clients Index Page after submit
        pageTitle == "Clients"
        // Make sure Created Clients is listed on page
        deleteClientLink clientIdGuid
        |> click
        Clients.Delete.pageTitle == "Delete Client - " + clientNameGuid
        Clients.Delete.pageDescription == "Are you sure you want to delete this client?"
        Clients.Delete.deleteActionAlert == "This action cannot be undone."
        click Clients.Delete.confirmDelete

    "should navigate to edit client page when Edit link is clicked" &&& fun _ ->
        // Create new client
        let guid = System.Guid.NewGuid().ToString()
        let clientIdGuid =  "client-id-" + guid
        let clientNameGuid = "Client Name " + guid
        createNewClient clientIdGuid clientNameGuid
        // Validate on Clients Index Page after submit
        pageTitle == "Clients"
        // Click on Edit button of new Client
        editClientLink clientIdGuid
        |> click
        // Validate on Client Edit page
        Clients.Edit.pageTitle == clientNameGuid + " (" + clientIdGuid + ")"
        deleteClient clientIdGuid

let all () =
  smoke()
  full()