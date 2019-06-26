module Tests

open Common

//The default argument passed from the console in the starter kit is UnderDevelopment
//This lets you simply comment/uncomment the test context/suite that you are working on
//As you add more tests for different pages, add an entry here
let underDevelopment () =
  Manage.Actions.edge()

//This is a list of all tests, which is useful when running in a CI environment where you want to
//run all tests, or a specific type of test like Full/Smoke, or tests for a specific
//page or set of functionality
//Its is a list of a tuple of 3 things, a Tag, TestType, and a the function that wraps your actual tests
//As you add more tests for different pages, add an entry/entries here
let all =
  [
    Actions, Smoke, Login.Actions.smoke
    Actions, Full, Login.Actions.full

    Assertions, Smoke, Home.Assertions.smoke
    Assertions, Full, Home.Assertions.full


    Actions, Smoke, Clients.Actions.smoke
    Actions, Full, Clients.Actions.full

    Assertions, Smoke, Clients.Assertions.smoke
    Assertions, Full, Clients.Assertions.full


    Actions, Smoke, Manage.Actions.smoke
    Actions, Full, Manage.Actions.full
    Actions, Edge, Manage.Actions.edge

    Assertions, Smoke, Manage.Assertions.smoke
    Assertions, Full, Manage.Assertions.full
    Assertions, Edge, Manage.Assertions.edge


    Actions, Smoke, Consent.Actions.smoke
    Actions, Full, Consent.Actions.full

    Assertions, Smoke, Consent.Assertions.smoke
    Assertions, Full, Consent.Assertions.full


    Actions, Smoke, Grants.Actions.smoke
    Actions, Full, Grants.Actions.full

    Assertions, Smoke, Grants.Assertions.smoke
    Assertions, Full, Grants.Assertions.full


    Actions, Smoke, Register.Actions.smoke
    Actions, Full, Register.Actions.full

    Assertions, Smoke, Register.Assertions.smoke
    Assertions, Full, Register.Assertions.full
  ]
  
//Code below does not need to be changed in most cases, it simply takes all of the tests and removes ones that dont
//meet the tags provided from arguments
let register tag testType =
  let exec predicate =
    all
    |> List.filter predicate
    |> List.iter (fun (_, _, func) -> func())

  match tag, testType with
  | (_, UnderDevelopment) -> underDevelopment()
  | (Tag.All, All)        -> exec (fun _ -> true)
  | (Tag.All, testType)   -> exec (fun (_, testType', _) -> testType' = testType)
  | (tag, All)            -> exec (fun (tag', _, _) -> tag' = tag)
  | (tag, testType)       -> exec (fun (tag', testType', _) -> tag' = tag && testType' = testType)