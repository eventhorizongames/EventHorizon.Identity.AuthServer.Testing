namespace EventHorizon.Identity.AuthServer.Testing.Register.Pages
{
    using Atata;
    using EventHorizon.Identity.AuthServer.Testing.Layout;
    using _ = RegisterPage;

    [Url("/register")]
    public class RegisterPage
        : MainLayoutPage<_>
    {
        [FindById("page-description")]
        public H2<_> PageDescription { get; private set; }

        [FindById("user-details")]
        public H3<_> UserDetails { get; private set; }

        [FindBySelector("UserRegistration_Email-label")]
        public Label<_> EmailLabel { get; private set; }
        public EmailInput<_> Email { get; private set; }

        [FindBySelector("UserRegistration_Password-label")]
        public Label<_> PasswordLabel { get; private set; }
        [FindById("UserRegistration_Password")]
        public PasswordInput<_> Password { get; private set; }

        [FindBySelector("UserRegistration_ConfirmPassword-label")]
        public Label<_> ConfirmPasswordLabel { get; private set; }
        [FindById("UserRegistration_ConfirmPassword")]
        public PasswordInput<_> ConfirmPassword { get; private set; }

        [FindById("user-profile")]
        public H3<_> UserProfile { get; private set; }

        [FindBySelector("UserRegistration_Profile_FirstName-label")]
        public Label<_> FirstNameLabel { get; private set; }
        [FindById("UserRegistration_Profile_FirstName")]
        public TextInput<_> FirstName { get; private set; }

        [FindBySelector("UserRegistration_Profile_LastName-label")]
        public Label<_> LastNameLabel { get; private set; }
        [FindById("UserRegistration_Profile_LastName")]
        public TextInput<_> LastName { get; private set; }

        [FindBySelector("UserRegistration_Profile_PhoneNumber-label")]
        public Label<_> PhoneNumberLabel { get; private set; }
        [FindById("UserRegistration_Profile_PhoneNumber")]
        public TelInput<_> PhoneNumber { get; private set; }

        [FindById("UserRegistration_AcceptServiceAgreements")]
        public CheckBox<_> ServiceAgreements { get; private set; }

        public Button<_> Register { get; private set; }
    }
}
