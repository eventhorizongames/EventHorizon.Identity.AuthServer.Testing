namespace EventHorizon.Identity.AuthServer.Testing.Logout.Pages
{
    using Atata;
    using _ = LogoutPage;

    [Url("/Account/Logout")]
    public class LogoutPage
        : Page<_>
    {
        [FindById("logout-confirm-button")]
        public Button<_> Yes { get; set; }
    }
}
