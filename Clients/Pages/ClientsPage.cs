namespace EventHorizon.Identity.AuthServer.Testing.Clients.Pages
{
    using Atata;

    using EventHorizon.Identity.AuthServer.Testing.Layout;

    using _ = ClientsPage;

    [Url("/Clients")]
    public class ClientsPage
        : MainLayoutPage<_>
    {
        public Link<ClientCreatePage, _> Create { get; private set; }

        public ControlList<ClientItem, _> Clients { get; private set; }

        [ControlDefinition("li", ContainingClass = "client")]
        public class ClientItem
            : Control<_>
        {
            [FindBySelector("client-display")]
            public Text<_> Display { get; private set; }

            [FindBySelector("client-edit")]
            public Link<ClientEditPage, _> Edit { get; private set; }

            [FindBySelector("client-delete")]
            public Link<ClientDeletePage, _> Delete { get; private set; }
        }
    }
}
