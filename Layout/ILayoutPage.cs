namespace EventHorizon.Identity.AuthServer.Testing.Layout
{
    using Atata;

    public interface ILayoutPage<TOwner>
        where TOwner : PageObject<TOwner>
    {
        TopBarComponent<TOwner> TopBar { get; }

        CookieBannerComponent<TOwner> CookieBanner { get; }
    }
}
