namespace EventHorizon.Identity.AuthServer.Testing.Manage.Pages
{
    using Atata;

    using EventHorizon.Identity.AuthServer.Testing.Manage.Layouts;

    using _ = ManagePage;

    [Url("/Manage")]
    public class ManagePage
        : ManageLayoutPage<_>
    {
        [FindById("profile-header")]
        public Text<_> ProfileHeader { get; private set; }

        [FindByClass("status-message")]
        public Text<_> StatusMessage { get; private set; }

        [FindBySelector("Username-label")]
        public Label<_> EmailLabel { get; private set; }
        [FindById("Username")]
        public TextInput<_> Email { get; private set; }

        [FindById("send-verification-email")]
        public Button<_> SendVerificationEmail { get; private set; }

        [FindBySelector("Profile_FirstName-label")]
        public Label<_> FirstNameLabel { get; private set; }
        [FindById("Profile_FirstName")]
        public TextInput<_> FirstName { get; private set; }

        [FindBySelector("Profile_LastName-label")]
        public Label<_> LastNameLabel { get; private set; }
        [FindById("Profile_LastName")]
        public TextInput<_> LastName { get; private set; }

        [FindBySelector("Profile_PhoneNumber-label")]
        public Label<_> PhoneNumberLabel { get; private set; }
        [FindById("Profile_PhoneNumber")]
        public TelInput<_> PhoneNumber { get; private set; }

        [FindById("save-profile")]
        public Button<_> Save { get; private set; }
    }
}
