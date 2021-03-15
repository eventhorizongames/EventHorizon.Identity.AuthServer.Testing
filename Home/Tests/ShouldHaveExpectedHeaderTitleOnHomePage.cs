namespace EventHorizon.Identity.AuthServer.Testing.Home.Tests
{
    using Atata;
    using EventHorizon.Identity.AuthServer.Testing.Core.Browser;
    using EventHorizon.Identity.AuthServer.Testing.Home.Pages;
    using Xunit;

    public class ShouldHaveExpectedHeaderTitleOnHomePage
        : WebHost
    {
        [Trait("Category", "Home Page")]
        [PrettyFact(nameof(ShouldHaveExpectedHeaderTitleOnHomePage))]
        public void Test()
        {
            this.Open<HomePage>()
                .Header.Should.Equal(
                    "Welcome to EventHorizon Games Studio Identity"
                )
            ;
        }
    }
}
