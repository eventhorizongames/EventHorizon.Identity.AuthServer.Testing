namespace EventHorizon.Identity.AuthServer.Testing.Account.Tests
{
    using Atata;

    using EventHorizon.Identity.AuthServer.Testing.Core.Browser;
    using EventHorizon.Identity.AuthServer.Testing.Data;
    using EventHorizon.Identity.AuthServer.Testing.Login.Pages;

    using Xunit;

    public class ShouldShowEmailErrorMessageWhenUsernameIsEmpty
        : WebHost
    {
        [Trait("Category", "Account Login Page")]
        [PrettyFact(nameof(ShouldShowEmailErrorMessageWhenUsernameIsEmpty))]
        public void Test()
        {
            Open<LoginPage>()
                .Email.Set(
                    string.Empty
                ).Password.Set(
                    IdentityServerData.DefaultAdminUser.Password
                ).Login.Click()
                .EmailErrorByInput.Should.Equal(
                    "The Email field is required."
                )
            ;
        }
    }
}
