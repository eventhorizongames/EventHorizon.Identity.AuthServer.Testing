namespace EventHorizon.Identity.AuthServer.Testing.Clients.Pages
{
    using Atata;

    using EventHorizon.Identity.AuthServer.Testing.Layout;

    using _ = ClientDeletePage;

    public class ClientDeletePage
        : MainLayoutPage<_>
    {
        public static string Url(
            string clientId
        ) => $"/Clients/Delete/{clientId}";

        [FindById("confirm")]
        public Button<ClientsPage, _> Confirm { get; private set; }
    }
}
