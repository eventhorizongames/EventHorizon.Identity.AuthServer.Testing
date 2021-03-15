namespace EventHorizon.Identity.AuthServer.Testing.Manage.Pages
{
    using Atata;

    using EventHorizon.Identity.AuthServer.Testing.Manage.Layouts;

    using _ = ManagePurgeAccountPage;

    [Url("/Manage/PurgeAccount")]
    public class ManagePurgeAccountPage
        : ManageLayoutPage<_>
    {
        [FindByClass("purge-account-description")]
        public Text<_> Description { get; private set; }

        [FindBySelector("purge-account-alert")]
        public Text<_> Alert { get; private set; }

        [FindById("confirm")]
        public Button<_> Confirm { get; private set; }

        [FindById("cancel")]
        public Button<_> Cancel { get; private set; }
    }
}
