namespace EventHorizon.Identity.AuthServer.Testing.Home.Tests
{
    using Atata;
    using EventHorizon.Identity.AuthServer.Testing.Core.Browser;
    using EventHorizon.Identity.AuthServer.Testing.Home.Pages;
    using Xunit;

    public class ShouldHaveExpectedSiteBrandOnHomePage
        : WebHost
    {
        [Trait("Category", "Home Page")]
        [PrettyFact(nameof(ShouldHaveExpectedSiteBrandOnHomePage))]
        public void Test()
        {
            this.Open<HomePage>()
                .TopBar.SiteBrand.Content.Should.Equal(
                    "EventHorizon Games Studio Identity"
                )
            ;
        }
    }
}
