namespace EventHorizon.Identity.AuthServer.Testing.Home.Pages
{
    using Atata;
    using EventHorizon.Identity.AuthServer.Testing.Layout;
    using _ = HomePage;

    [Url("/")]
    public class HomePage
        : Page<_>,
        ILayoutPage<_>
    {
        [FindById("home-page-title")]
        public H1<_> Header { get; private set; }

        public TopBarComponent<_> TopBar { get; private set; }
        public CookieBannerComponent<_> CookieBanner { get; private set; }
    }
}
