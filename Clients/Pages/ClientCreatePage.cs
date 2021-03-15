namespace EventHorizon.Identity.AuthServer.Testing.Clients.Pages
{
    using Atata;

    using EventHorizon.Identity.AuthServer.Testing.Layout;

    using _ = ClientCreatePage;

    [Url("/Clients/Create")]
    public class ClientCreatePage
        : MainLayoutPage<_>
    {
        [FindBySelector("client-id-label")]
        public Label<_> IdLabel { get; private set; }
        [FindById("Client_Id")]
        public TextInput<_> Id { get; private set; }

        [FindBySelector("client-name-label")]
        public Label<_> NameLabel { get; private set; }
        [FindById("Client_Name")]
        public TextInput<_> Name { get; private set; }

        [FindById("create-client")]
        public Button<ClientsPage, _> Create { get; private set; }
    }
}
