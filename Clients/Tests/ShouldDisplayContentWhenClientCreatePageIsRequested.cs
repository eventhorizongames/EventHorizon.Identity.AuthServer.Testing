namespace EventHorizon.Identity.AuthServer.Testing.Clients.Tests
{
    using Atata;

    using EventHorizon.Identity.AuthServer.Testing.Clients.Pages;
    using EventHorizon.Identity.AuthServer.Testing.Core.Browser;
    using EventHorizon.Identity.AuthServer.Testing.Data;
    using EventHorizon.Identity.AuthServer.Testing.Login.Pages;

    using Xunit;

    public class ShouldDisplayContentWhenClientCreatePageIsRequested
        : WebHost
    {
        [Trait("TestType", "Smoke")]
        [Trait("Category", "Client Create Page")]
        [PrettyFact(nameof(ShouldDisplayContentWhenClientCreatePageIsRequested))]
        public void Test()
        {
            this.LoginWithAdmin<ClientCreatePage>()
                .Header.Should.Equal("Client Create")
                .IdLabel.Should.Equal("New Client Id")
                .NameLabel.Should.Equal("New Client Name")
                .Create.Content.Should.Equal("Create")
            ;
        }
    }
}
