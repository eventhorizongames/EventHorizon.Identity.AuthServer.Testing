namespace EventHorizon.Identity.AuthServer.Testing.Clients.Tests
{
    using System;

    using Atata;

    using EventHorizon.Identity.AuthServer.Testing.Clients.Pages;
    using EventHorizon.Identity.AuthServer.Testing.Core.Browser;
    using EventHorizon.Identity.AuthServer.Testing.Data;

    using Xunit;

    public class ShouldDeleteClientWhenDeleteLinkClick
        : WebHost
    {
        protected readonly string _guid;
        protected readonly string _clientId;
        protected readonly string _clientName;

        public ShouldDeleteClientWhenDeleteLinkClick()
        {
            _guid = Guid.NewGuid().ToString();
            _clientId = $"client-id-{_guid}";
            _clientName = $"Client Name - {_guid}";
        }

        [Trait("Category", "Clients Page")]
        [PrettyFact(nameof(ShouldDeleteClientWhenDeleteLinkClick))]
        public void Test()
        {
            this.LoginWithAdmin<ClientCreatePage>()
                .Id.Set(_clientId)
                .Name.Set(_clientName)
                .Create.ClickAndGo()
                .Header.Should.Equal("Clients")

                .Clients.FindByKey(_clientId)
                    .Delete.ClickAndGo()
                    .Confirm.ClickAndGo()

                .Header.Should.Equal("Clients")
            ;
        }
    }
}
