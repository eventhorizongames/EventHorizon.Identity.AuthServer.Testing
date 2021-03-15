namespace EventHorizon.Identity.AuthServer.Testing.Core.Browser
{

    using Atata;

    using EventHorizon.Identity.AuthServer.Testing.Consent.Pages;

    public static class ConsentWebHostExtensions
    {
        public static WebHost WhenAccessToSpecificClientAccepted(
            this WebHost webHost,
            string clientId,
            string redirectUri
        )
        {
            webHost.Open<ConsentPage>(
                ConsentPage.Url(
                    clientId,
                    redirectUri
                )
            )
            .Yes.Click();

            return webHost;
        }
    }
}
