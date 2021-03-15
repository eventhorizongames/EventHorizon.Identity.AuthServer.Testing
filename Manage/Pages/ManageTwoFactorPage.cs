namespace EventHorizon.Identity.AuthServer.Testing.Manage.Pages
{
    using Atata;

    using EventHorizon.Identity.AuthServer.Testing.Manage.Layouts;

    using _ = ManageTwoFactorPage;

    [Url("/Manage/TwoFactor")]
    public class ManageTwoFactorPage
        : ManageLayoutPage<_>
    {
        [FindById("two-factor-header")]
        public Text<_> TwoFactorHeader { get; private set; }

        [FindById("two-factor-sub-header")]
        public Text<_> TwoFactorSubHeader { get; private set; }

        [FindById("add-two-factor-app")]
        public Link<_> AddApp { get; private set; }
    }
}
