namespace EventHorizon.Identity.AuthServer.Testing.Register.Tests
{
    using Atata;

    using EventHorizon.Identity.AuthServer.Testing.Core.Browser;
    using EventHorizon.Identity.AuthServer.Testing.Register.Pages;

    using Xunit;

    public class ShouldDisplayContentWhenRegisterPageRequested
        : WebHost
    {
        [Trait("TestType", "Smoke")]
        [Trait("Category", "Register Page")]
        [PrettyFact(nameof(ShouldDisplayContentWhenRegisterPageRequested))]
        public void Test()
        {
            this.Open<RegisterPage>()
                .Header.Should.Equal("Register")
                .PageDescription.Should.Equal("Create a new account.")
                .UserDetails.Should.Equal("Account Details")
                    .EmailLabel.Should.Equal("Email")
                    .Email.Should.BeVisible()
                    .PasswordLabel.Should.Equal("Password")
                    .Password.Should.BeVisible()
                    .ConfirmPasswordLabel.Should.Equal("Confirm password")
                    .ConfirmPassword.Should.BeVisible()
                .UserProfile.Should.Equal("Account Profile")
                    .FirstNameLabel.Should.Equal("First name")
                    .FirstName.Should.BeVisible()
                    .LastNameLabel.Should.Equal("Last name")
                    .LastName.Should.BeVisible()
                    .PhoneNumberLabel.Should.Equal("Phone number")
                    .PhoneNumber.Should.BeVisible()
                .Register.Content.Should.Equal("Register")
                .Register.Should.BeVisible()
            ;
        }
    }
}
