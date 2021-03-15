namespace EventHorizon.Identity.AuthServer.Testing.Core.Browser
{

    using Atata;

    using EventHorizon.Identity.AuthServer.Testing.Grants.Pages;

    public static class GrantsWebHostExtensions
    {
        public static WebHost WhenAccessToSpecificClientRevoked(
            this WebHost webHost,
            string clientId
        )
        {
            Go.To<GrantsPage>()
                .Do(grantPage =>
                {
                    var grant = grantPage.Grants.FindByClientId(
                        clientId
                    );
                    if (grant.IsPresent)
                    {
                        grant.Revoke.Click();
                    }
                }
            );

            return webHost;
        }
    }
}
