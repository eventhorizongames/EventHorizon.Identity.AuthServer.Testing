namespace EventHorizon.Identity.AuthServer.Testing.Grants.Tests
{
    using System;

    using Atata;

    using EventHorizon.Identity.AuthServer.Testing.Core.Browser;
    using EventHorizon.Identity.AuthServer.Testing.Data;
    using EventHorizon.Identity.AuthServer.Testing.Grants.Pages;
    using EventHorizon.Identity.AuthServer.Testing.Models;

    using Xunit;

    public class ShouldDisplayContentWhenGrantsPageIsRequested
        : WebHost
    {
        [Trait("TestType", "Smoke")]
        [Trait("Category", "Grants Page")]
        [PrettyFact(nameof(ShouldDisplayContentWhenGrantsPageIsRequested))]
        public void Test()
        {
            this.LoginWithNewUser(out _)
                .WhenAccessToSpecificClientAccepted(
                    IdentityServerData.ClientId,
                    IdentityServerData.RedirectUri
                ).Open<GrantsPage>()
                .Header.Should.Equal("Client Application Access")
                .Grants.FindByClientId(IdentityServerData.ClientId)
                    .AssertByAction<GrantsPage.GrantItem, GrantsPage>(item =>
                    {
                        var now = DateTime.UtcNow;
                        item.ClientName.Should.Equal(IdentityServerData.ClientId);

                        var expectedCreated = $"Created: {now.Year}-{now.Month:D2}-{now.Day:D2}";
                        item.CreatedLabel.Should.Equal("Created:");
                        item.Created.Should.Equal(expectedCreated);

                        item.IdentityGrantTypesLabel.Should.Equal("Identity Grants");
                        item.IdentityGrantTypes[0].Label.Should.Equal("User profile");
                        item.IdentityGrantTypes[1].Label.Should.Equal("Your user identifier");

                        item.ApiGrantTypesLabel.Should.Equal("API Grants");
                        var content = item.ApiGrantTypes[0].Label.Content;
                        item.ApiGrantTypes[0].Label.Should.Equal("Email");
                        item.ApiGrantTypes[1].Label.Should.Equal("Role");
                    })
            ;
        }
    }
}
