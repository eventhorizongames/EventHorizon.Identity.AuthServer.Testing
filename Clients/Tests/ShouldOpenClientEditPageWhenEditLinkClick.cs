namespace EventHorizon.Identity.AuthServer.Testing.Clients.Tests
{
    using Atata;

    using EventHorizon.Identity.AuthServer.Testing.Clients.Base;
    using EventHorizon.Identity.AuthServer.Testing.Clients.Pages;
    using EventHorizon.Identity.AuthServer.Testing.Core.Browser;
    using EventHorizon.Identity.AuthServer.Testing.Login.Pages;

    using Xunit;

    public class ShouldOpenClientEditPageWhenEditLinkClick
        : ClientsWebHost
    {
        [Trait("Category", "Clients Page")]
        [PrettyFact(nameof(ShouldOpenClientEditPageWhenEditLinkClick))]
        public void Test()
        {
            this.LoginWithAdmin<ClientCreatePage>()
                .Id.Set(_clientId)
                .Name.Set(_clientName)
                .Create.ClickAndGo()
                .Header.Should.Equal("Clients")

                .Clients.FindByKey(_clientId)
                    .Edit.ClickAndGo()

                .Header.Should.Equal(
                    "Client Edit"
                )
            ;
        }
    }
}
