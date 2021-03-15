namespace EventHorizon.Identity.AuthServer.Testing.Login.Pages
{
    using Atata;

    using EventHorizon.Identity.AuthServer.Testing.Account.Pages;
    using EventHorizon.Identity.AuthServer.Testing.Home.Pages;
    using EventHorizon.Identity.AuthServer.Testing.Layout;
    using EventHorizon.Identity.AuthServer.Testing.Register.Pages;

    using _ = LoginPage;

    [Url(LoginPageUrl)]
    public class LoginPage
        : MainLayoutPage<_>
    {
        public const string LoginPageUrl = "/account/login";

        public H1<_> Header { get; private set; }

        [FindByClass("panel-title")]
        public H3<_> LocalPanel { get; private set; }

        [FindBySelector("email-label")]
        public Label<_> EmailLabel { get; private set; }
        public EmailInput<_> Email { get; private set; }
        [FindBySelector("email-help-block")]
        public Text<_> EmailHelpBlock { get; private set; }

        [FindBySelector("password-label")]
        public Label<_> PasswordLabel { get; private set; }
        public PasswordInput<_> Password { get; private set; }

        [FindBySelector("reset-password-link")]
        public Link<ForgotPasswordPage, _> ResetPassword { get; private set; }

        [FindBySelector("remember-login-label")]
        public Label<_> RememberLoginLabel { get; private set; }

        [FindById("login-button")]
        public Button<HomePage, _> Login { get; private set; }

        [FindById("cancel-login-button")]
        public Button<HomePage, _> Cancel { get; private set; }

        [FindById("register-new-user-link")]
        public Link<RegisterPage, _> RegisterNewUser { get; private set; }

        [FindBySelector("validation-summary-all")]
        public Text<_> ValidationSummary { get; private set; }

        [FindBySelector("email-validation-message")]
        public Text<_> EmailErrorByInput { get; private set; }

        [FindBySelector("password-validation-message")]
        public Text<_> PasswordErrorByInput { get; private set; }
    }
}
