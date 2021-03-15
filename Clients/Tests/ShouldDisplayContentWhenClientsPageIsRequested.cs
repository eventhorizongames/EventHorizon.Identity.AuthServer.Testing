namespace EventHorizon.Identity.AuthServer.Testing.Clients.Tests
{
    using Atata;

    using EventHorizon.Identity.AuthServer.Testing.Clients.Pages;
    using EventHorizon.Identity.AuthServer.Testing.Core.Browser;

    using Xunit;

    public class ShouldDisplayContentWhenClientsPageIsRequested
        : WebHost
    {
        [Trait("TestType", "Smoke")]
        [Trait("Category", "Clients Page")]
        [PrettyFact(nameof(ShouldDisplayContentWhenClientsPageIsRequested))]
        public void Test()
        {
            this.LoginWithAdmin<ClientsPage>()
                .Header.Should.Equal("Clients")
                .Create.Content.Should.Equal("Create")
            ;
        }
    }
}
