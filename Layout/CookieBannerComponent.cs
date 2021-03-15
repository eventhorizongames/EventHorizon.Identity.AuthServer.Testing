namespace EventHorizon.Identity.AuthServer.Testing.Layout
{
    using System;
    using Atata;

    public class CookieBannerComponent<TNavigateTo>
        : Control<TNavigateTo>
            where TNavigateTo : PageObject<TNavigateTo>
    {
        [FindByCss(".cookie-banner__button")]
        [WaitFor(ThrowOnPresenceFailure = false, PresenceTimeout = 0.1, RetryInterval = 0.1)]
        public Button<TNavigateTo> AcceptAndClose { get; private set; }
    }
}
