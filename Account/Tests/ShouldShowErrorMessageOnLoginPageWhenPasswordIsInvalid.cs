namespace EventHorizon.Identity.AuthServer.Testing.Account.Tests
{
    using Atata;

    using EventHorizon.Identity.AuthServer.Testing.Core.Browser;
    using EventHorizon.Identity.AuthServer.Testing.Data;
    using EventHorizon.Identity.AuthServer.Testing.Login.Pages;

    using Xunit;

    public class ShouldShowErrorMessageOnLoginPageWhenPasswordIsInvalid
        : WebHost
    {
        [Trait("Category", "Account Login Page")]
        [PrettyFact(nameof(ShouldShowEmailErrorMessageWhenUsernameIsEmpty))]
        public void Test()
        {
            Open<LoginPage>()
                .Email.Set(
                    IdentityServerData.DefaultAdminUser.Email
                ).Password.Set(
                    "invalid password"
                ).Login.Click()
                .ValidationSummary.Should.Equal(
                    "Invalid username or password"
                )
            ;
        }
    }
}
