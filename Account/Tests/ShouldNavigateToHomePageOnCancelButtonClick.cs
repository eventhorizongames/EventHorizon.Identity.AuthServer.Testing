namespace EventHorizon.Identity.AuthServer.Testing.Account.Tests
{
    using Atata;

    using EventHorizon.Identity.AuthServer.Testing.Core.Browser;
    using EventHorizon.Identity.AuthServer.Testing.Login.Pages;

    using Xunit;

    public class ShouldNavigateToHomePageOnCancelButtonClick
        : WebHost
    {
        [Trait("Category", "Account Login Page")]
        [PrettyFact(nameof(ShouldNavigateToHomePageOnCancelButtonClick))]
        public void Test()
        {
            this.Open<LoginPage>()
                .Cancel.ClickAndGo()
                .Header.Should.Equal(
                    "Welcome to EventHorizon Games Studio Identity"
                )
            ;
        }
    }
}
