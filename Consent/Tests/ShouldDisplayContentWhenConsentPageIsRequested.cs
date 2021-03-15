namespace EventHorizon.Identity.AuthServer.Testing.Consent.Tests
{
    using System;

    using Atata;

    using EventHorizon.Identity.AuthServer.Testing.Consent.Pages;
    using EventHorizon.Identity.AuthServer.Testing.Core.Browser;
    using EventHorizon.Identity.AuthServer.Testing.Data;
    using EventHorizon.Identity.AuthServer.Testing.Models;

    using Xunit;

    public class ShouldDisplayContentWhenConsentPageIsRequested
        : WebHost
    {
        [Trait("TestType", "Smoke")]
        [Trait("Category", "Consent Page")]
        [PrettyFact(nameof(ShouldDisplayContentWhenConsentPageIsRequested))]
        public void Test()
        {
            this.LoginWithNewUser(out _)
                .Open<ConsentPage>(
                    ConsentPage.Url(
                        IdentityServerData.ClientId,
                        IdentityServerData.RedirectUri
                    )
                )
                .Header.Should.Equal($"{IdentityServerData.ClientId} is requesting your permission")
                .Description.Should.Equal("Uncheck the permissions you do not wish to grant.")
                .Yes.Content.Should.Equal("Yes, Allow")
                .No.Content.Should.Equal("No, Do Not Allow")

                .PersonalInfoHeading.Should.Equal("Personal Information")
                .PersonalInfoScopes.FindByKey("scopes_openid")
                    .Label.Should.Equal("Your user identifier")
                .PersonalInfoScopes.FindByKey("scopes_profile")
                    .Label.Should.Equal("User profile")

                .ApplicationAccessHeading.Should.Equal("Application Access")
                .ApplicationAccessScopes.FindByKey("scopes_email")
                    .Label.Should.Equal("email")
                .ApplicationAccessScopes.FindByKey("scopes_roles")
                    .Label.Should.Equal("roles")

                .AccessDescriptionLabel.Should.Equal("Description")
                .RememberDecisionLabel.Should.Equal("Remember My Decision")

                .ClientUrl.Content.Should.Equal(IdentityServerData.ClientId)
            ;
        }
    }
}
