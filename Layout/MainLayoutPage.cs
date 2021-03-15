namespace EventHorizon.Identity.AuthServer.Testing.Layout
{
    using System;

    using Atata;

    public abstract class MainLayoutPage<TOwner>
        : Page<TOwner>,
        ILayoutPage<TOwner> where TOwner : Page<TOwner>
    {
        public TopBarComponent<TOwner> TopBar { get; private set; }
        public CookieBannerComponent<TOwner> CookieBanner { get; private set; }

        [FindById("page-title")]
        public H1<TOwner> Header { get; private set; }
    }
}
