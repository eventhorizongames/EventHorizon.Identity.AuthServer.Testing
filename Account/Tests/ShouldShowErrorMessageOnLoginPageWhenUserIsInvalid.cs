namespace EventHorizon.Identity.AuthServer.Testing.Account.Tests
{
    using Atata;

    using EventHorizon.Identity.AuthServer.Testing.Core.Browser;
    using EventHorizon.Identity.AuthServer.Testing.Data;
    using EventHorizon.Identity.AuthServer.Testing.Login.Pages;

    using Xunit;

    public class ShouldShowErrorMessageOnLoginPageWhenUserIsInvalid
        : WebHost
    {
        [Trait("Category", "Account Login Page")]
        [PrettyFact(nameof(ShouldShowEmailErrorMessageWhenUsernameIsEmpty))]
        public void Test()
        {
            Open<LoginPage>()
                .Email.Set(
                    "invalid username"
                ).Password.Set(
                    IdentityServerData.DefaultAdminUser.Password
                ).Login.Click()
                .EmailErrorByInput.Should.Equal(
                    "The Email field is not a valid e-mail address."
                )
            ;
        }
    }
}
