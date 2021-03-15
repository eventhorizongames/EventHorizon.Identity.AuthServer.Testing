namespace EventHorizon.Identity.AuthServer.Testing.Account.Tests
{
    using Atata;

    using EventHorizon.Identity.AuthServer.Testing.Core.Browser;
    using EventHorizon.Identity.AuthServer.Testing.Data;
    using EventHorizon.Identity.AuthServer.Testing.Login.Pages;

    using Xunit;

    public class ShouldRedirectToHomePageWhenSuccessfulLogin
        : WebHost
    {
        [Trait("TestType", "Smoke")]
        [Trait("Category", "Account Login Page")]
        [PrettyFact(nameof(ShouldRedirectToHomePageWhenSuccessfulLogin))]
        public void Test()
        {
            this.Open<LoginPage>()
                .Email.Set(
                    IdentityServerData.DefaultAdminUser.Email
                ).Password.Set(
                    IdentityServerData.DefaultAdminUser.Password
                ).Login.ClickAndGo()
                .Header.Should.Equal(
                    "Welcome to EventHorizon Games Studio Identity"
                )
            ;
        }
    }
}
