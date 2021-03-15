namespace EventHorizon.Identity.AuthServer.Testing.Consent.Tests
{
    using System;

    using Atata;

    using EventHorizon.Identity.AuthServer.Testing.Consent.Pages;
    using EventHorizon.Identity.AuthServer.Testing.Core.Browser;
    using EventHorizon.Identity.AuthServer.Testing.Data;
    using EventHorizon.Identity.AuthServer.Testing.Home.Pages;
    using EventHorizon.Identity.AuthServer.Testing.Models;

    using Xunit;

    public class ShouldBeOnRedirectUriPageWhenAllowAccessClicked
        : WebHost
    {
        [Trait("Category", "Consent Page")]
        [PrettyFact(nameof(ShouldBeOnRedirectUriPageWhenAllowAccessClicked))]
        public void Test()
        {
            this.LoginWithNewUser(out _)
                .Open<ConsentPage>(
                    ConsentPage.Url(
                        IdentityServerData.ClientId,
                        IdentityServerData.RedirectUri
                    )
                )
                .Yes.ClickAndGo<HomePage>()
                .Header.Should.Equal("Welcome to EventHorizon Games Studio Identity")
            ;
        }
    }
}
