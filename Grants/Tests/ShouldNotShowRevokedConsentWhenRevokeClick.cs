namespace EventHorizon.Identity.AuthServer.Testing.Grants.Tests
{
    using System;

    using Atata;

    using EventHorizon.Identity.AuthServer.Testing.Consent.Pages;
    using EventHorizon.Identity.AuthServer.Testing.Core.Browser;
    using EventHorizon.Identity.AuthServer.Testing.Data;
    using EventHorizon.Identity.AuthServer.Testing.Grants.Pages;
    using EventHorizon.Identity.AuthServer.Testing.Models;

    using Xunit;

    public class ShouldShowAcceptedConsentWhenFistAcceptingAccess
        : WebHost
    {
        [Trait("Category", "Grants Page")]
        [PrettyFact(nameof(ShouldShowAcceptedConsentWhenFistAcceptingAccess))]
        public void Test()
        {
            this.LoginWithNewUser<GrantsPage>(out _)
                .Grants.Should.HaveCount(0);

            this.WhenAccessToSpecificClientAccepted(
                IdentityServerData.ClientId,
                IdentityServerData.RedirectUri
            ).Open<GrantsPage>()

            .Grants.FindByClientId(IdentityServerData.ClientId)
                .ClientName.Should.Equal(IdentityServerData.ClientId);
            ;
        }
    }
}
