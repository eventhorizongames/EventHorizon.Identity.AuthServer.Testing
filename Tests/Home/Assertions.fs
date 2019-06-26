module Home.Assertions

open canopy.classic
open canopy.runner.classic
open Home.Index

let smoke () =
  context "smoke Home assertions"
  before (fun _ -> url Home.Index.uri)

  ".navbar-brand should have EventHorizon Game Studio Identity" &&& fun _ ->
    navBarTitle == "EventHorizon Game Studio Identity"

let full () =
  context "full Home assertions"
  before (fun _ -> url Home.Index.uri)

  ".home-page-title should have Welcome to EventHorizon Game Studio Identity" &&& fun _ ->
    pageTitle == pageTitleText



let all () =
  smoke()
  full()