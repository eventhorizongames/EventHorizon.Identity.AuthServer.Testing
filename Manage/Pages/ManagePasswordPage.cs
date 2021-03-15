namespace EventHorizon.Identity.AuthServer.Testing.Manage.Pages
{
    using Atata;

    using EventHorizon.Identity.AuthServer.Testing.Manage.Layouts;

    using _ = ManagePasswordPage;

    [Url("/Manage/ChangePassword")]
    public class ManagePasswordPage
        : ManageLayoutPage<_>
    {
        [FindById("change-password-header")]
        public Text<_> PasswordHeader { get; private set; }

        [FindBySelector("ChangePasswordModel_OldPassword-label")]
        public Label<_> CurrentPasswordLabel { get; private set; }
        [FindById("ChangePasswordModel_OldPassword")]
        public TextInput<_> CurrentPassword { get; private set; }

        [FindBySelector("ChangePasswordModel_NewPassword-label")]
        public Label<_> NewPasswordLabel { get; private set; }
        [FindById("ChangePasswordModel_NewPassword")]
        public TextInput<_> NewPassword { get; private set; }

        [FindBySelector("ChangePasswordModel_ConfirmPassword-label")]
        public Label<_> ConfirmPasswordLabel { get; private set; }
        [FindById("ChangePasswordModel_ConfirmPassword")]
        public TextInput<_> ConfirmPassword { get; private set; }

        [FindById("update-password")]
        public Button<_> UpdatePassword { get; private set; }
    }
}
