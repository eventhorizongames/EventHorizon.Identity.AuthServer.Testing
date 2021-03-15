namespace EventHorizon.Identity.AuthServer.Testing.Manage.Tests
{
    using Atata;

    using EventHorizon.Identity.AuthServer.Testing.Core.Browser;
    using EventHorizon.Identity.AuthServer.Testing.Manage.Pages;

    using Xunit;

    public class ShouldDisplayContentWhenManagePagesRequested
        : WebHost
    {
        [Trait("TestType", "Smoke")]
        [Trait("Category", "Manage Page")]
        [PrettyFact(nameof(ShouldDisplayContentWhenManagePagesRequested))]
        public void Test()
        {
            this.LoginWithNewUser<ManagePage>(out var user)
                .SideBar.Profile.Click()
                    .ProfileHeader.Should.Equal("Profile")
                    .SendVerificationEmail.Content.Should.Equal("Send verification email")
                    .EmailLabel.Should.Equal("Email")
                    .Email.Should.Equal(user.Email)
                    .FirstNameLabel.Should.Equal("First name")
                    .LastNameLabel.Should.Equal("Last name")
                    .PhoneNumberLabel.Should.Equal("Phone number")
                    .Save.Content.Should.Equal("Save")
                .SideBar.Password.ClickAndGo()
                    .PasswordHeader.Should.Equal("Change password")
                    .CurrentPasswordLabel.Should.Equal("Current password")
                    .NewPasswordLabel.Should.Equal("New password")
                    .ConfirmPasswordLabel.Should.Equal("Confirm new password")
                .SideBar.TwoFactor.ClickAndGo()
                    .TwoFactorHeader.Should.Equal("Two-factor authentication")
                    .TwoFactorSubHeader.Should.Equal("Authenticator app")
                    .AddApp.Content.Should.Equal("Add authenticator app")
                .SideBar.PurgeAccount.ClickAndGo()
                    .Description.Should.Equal("Are you sure you want to purge your account?")
                    .Alert.Should.Equal("This action cannot be undone.")
                    .Confirm.Content.Should.Equal("Confirm")
                    .Cancel.Content.Should.Equal("Cancel")
            ;
        }
    }
}
