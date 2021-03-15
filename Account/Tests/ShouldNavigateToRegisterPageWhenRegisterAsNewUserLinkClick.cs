namespace EventHorizon.Identity.AuthServer.Testing.Account.Tests
{
    using Atata;

    using EventHorizon.Identity.AuthServer.Testing.Core.Browser;
    using EventHorizon.Identity.AuthServer.Testing.Login.Pages;

    using Xunit;

    public class ShouldNavigateToRegisterPageWhenRegisterAsNewUserLinkClick
        : WebHost
    {
        [Trait("Category", "Account Login Page")]
        [PrettyFact(nameof(ShouldNavigateToRegisterPageWhenRegisterAsNewUserLinkClick))]
        public void Test()
        {
            this.Open<LoginPage>()
                .RegisterNewUser.ClickAndGo()
                .Header.Should.Equal(
                    "Register"
                )
            ;
        }
    }
}
