namespace EventHorizon.Identity.AuthServer.Testing.Account.Tests
{
    using Atata;

    using EventHorizon.Identity.AuthServer.Testing.Core.Browser;
    using EventHorizon.Identity.AuthServer.Testing.Login.Pages;

    using Xunit;

    public class ShouldDisplayStandardLoginPageWhenFirstRequested
        : WebHost
    {
        [Trait("TestType", "Smoke")]
        [Trait("Category", "Account Login Page")]
        [PrettyFact(nameof(ShouldDisplayStandardLoginPageWhenFirstRequested))]
        public void Test()
        {
            Open<LoginPage>()
                .Header.Should.Equal(
                    "Login"
                ).LocalPanel.Should.Equal(
                    "Local Login"
                ).EmailLabel.Should.Equal(
                    "Email"
                ).EmailHelpBlock.Should.Equal(
                    "The email you registered with."
                ).PasswordLabel.Should.Equal(
                    "Password"
                ).ResetPassword.Content.Should.Equal(
                    "Reset Password?"
                ).RememberLoginLabel.Should.Equal(
                    "Remember My Login"
                ).Login.Content.Should.Equal(
                    "Login"
                ).Cancel.Content.Should.Equal(
                    "Cancel"
                ).RegisterNewUser.Content.Should.Equal(
                    "Register as a new user?"
                )
            ;
        }
    }
}
