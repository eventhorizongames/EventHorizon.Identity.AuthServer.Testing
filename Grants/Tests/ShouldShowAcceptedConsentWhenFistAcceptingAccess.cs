namespace EventHorizon.Identity.AuthServer.Testing.Grants.Tests
{

    using Atata;

    using EventHorizon.Identity.AuthServer.Testing.Core.Browser;
    using EventHorizon.Identity.AuthServer.Testing.Data;
    using EventHorizon.Identity.AuthServer.Testing.Grants.Pages;

    using Xunit;

    public class ShouldNotShowRevokedConsentWhenRevokeClick
        : WebHost
    {
        [Trait("Category", "Grants Page")]
        [PrettyFact(nameof(ShouldNotShowRevokedConsentWhenRevokeClick))]
        public void Test()
        {
            this.LoginWithNewUser(out _)
                .WhenAccessToSpecificClientAccepted(
                    IdentityServerData.ClientId,
                    IdentityServerData.RedirectUri
                ).Open<GrantsPage>()
                .Grants.FindByClientId(IdentityServerData.ClientId)
                    .Revoke.Click()
                .Grants.Should.HaveCount(0)
            ;
        }
    }
}
