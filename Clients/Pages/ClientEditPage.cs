namespace EventHorizon.Identity.AuthServer.Testing.Clients.Pages
{
    using System;

    using Atata;

    using EventHorizon.Identity.AuthServer.Testing.Layout;

    using _ = ClientEditPage;

    public class ClientEditPage
        : MainLayoutPage<_>
    {
        public static string Url(
            string clientId
        ) => $"/Client/Edit/{clientId}";

    }
}
