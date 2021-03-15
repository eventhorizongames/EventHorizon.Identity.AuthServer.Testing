namespace EventHorizon.Identity.AuthServer.Testing.Manage.Layouts
{
    using System;

    using Atata;

    using EventHorizon.Identity.AuthServer.Testing.Diagnostics.Pages;
    using EventHorizon.Identity.AuthServer.Testing.Grants.Pages;
    using EventHorizon.Identity.AuthServer.Testing.Manage.Pages;

    public class ManageSideBarComponent<TNavigateTo>
        : Control<TNavigateTo> where TNavigateTo : PageObject<TNavigateTo>
    {
        [FindById("open-profile")]
        public Link<ManagePage, TNavigateTo> Profile { get; private set; }

        [FindById("open-password")]
        public Link<ManagePasswordPage, TNavigateTo> Password { get; private set; }

        [FindById("open-two-factor")]
        public Link<ManageTwoFactorPage, TNavigateTo> TwoFactor { get; private set; }

        [FindById("open-grants")]
        public Link<GrantsPage, TNavigateTo> Grants { get; private set; }

        [FindById("open-diagnostics")]
        public Link<DiagnosticsPage, TNavigateTo> Diagnostics { get; private set; }

        [FindById("purge-account")]
        public Link<ManagePurgeAccountPage, TNavigateTo> PurgeAccount { get; private set; }
    }
}
