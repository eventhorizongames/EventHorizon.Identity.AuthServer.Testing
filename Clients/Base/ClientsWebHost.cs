namespace EventHorizon.Identity.AuthServer.Testing.Clients.Base
{
    using System;

    using Atata;

    using EventHorizon.Identity.AuthServer.Testing.Clients.Pages;
    using EventHorizon.Identity.AuthServer.Testing.Core.Browser;

    public abstract class ClientsWebHost
        : WebHost,
        IDisposable
    {
        protected readonly string _guid;
        protected readonly string _clientId;
        protected readonly string _clientName;

        public ClientsWebHost()
        {
            _guid = Guid.NewGuid().ToString();
            _clientId = $"client-id-{_guid}";
            _clientName = $"Client Name - {_guid}";
        }

        public void Dispose()
        {
            try
            {
                Go.To<ClientDeletePage>(
                    url: ClientDeletePage.Url(
                        _clientId
                    )
                ).Confirm.ClickAndGo()
                .Header.Should.Equal(
                    "Clients"
                );
            }
            catch { }
        }
    }
}
