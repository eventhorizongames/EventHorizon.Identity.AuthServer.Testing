namespace EventHorizon.Identity.AuthServer.Testing.Account.Tests
{
    using Atata;

    using EventHorizon.Identity.AuthServer.Testing.Core.Browser;
    using EventHorizon.Identity.AuthServer.Testing.Data;
    using EventHorizon.Identity.AuthServer.Testing.Login.Pages;

    using Xunit;

    public class ShouldShowErrorMessageOnLoginPageWhenPasswordIsEmpty
        : WebHost
    {
        [Trait("Category", "Account Login Page")]
        [PrettyFact(nameof(ShouldShowErrorMessageOnLoginPageWhenPasswordIsEmpty))]
        public void Test()
        {
            Open<LoginPage>()
                .Email.Set(
                    IdentityServerData.DefaultAdminUser.Email
                ).Password.Set(
                    string.Empty
                ).Login.Click()
                .PasswordErrorByInput.Should.Equal(
                    "The Password field is required."
                )
            ;
        }
    }
}
