namespace EventHorizon.Identity.AuthServer.Testing.Clients.Tests
{
    using Atata;

    using EventHorizon.Identity.AuthServer.Testing.Clients.Base;
    using EventHorizon.Identity.AuthServer.Testing.Clients.Pages;
    using EventHorizon.Identity.AuthServer.Testing.Core.Browser;
    using EventHorizon.Identity.AuthServer.Testing.Data;

    using Xunit;

    public class ShouldCreateNewClientWhenFormSubmitted
        : ClientsWebHost
    {
        [Trait("Category", "Client Create Page")]
        [PrettyFact(nameof(ShouldCreateNewClientWhenFormSubmitted))]
        public void Test()
        {
            this.LoginWithAdmin<ClientCreatePage>()
                .Id.Set(_clientId)
                .Name.Set(_clientName)
                .Create.ClickAndGo()
                .Header.Should.Equal("Clients")

                .Clients.FindByKey(_clientId)
                    .Display.Should.Equal($"{_clientName} ({_clientId})")
            ;
        }
    }
}
