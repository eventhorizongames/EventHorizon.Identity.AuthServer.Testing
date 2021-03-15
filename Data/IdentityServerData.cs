namespace EventHorizon.Identity.AuthServer.Testing.Data
{
    using EventHorizon.Identity.AuthServer.Testing.Core.Config;
    using EventHorizon.Identity.AuthServer.Testing.Models;

    using Microsoft.Extensions.Configuration;

    public class IdentityServerData
    {
        public static string Url { get; } = string.Empty;
        public static string EmailDomain { get; } = string.Empty;
        public static string DefaultPassword { get; } = string.Empty;

        public static IdentityServerUser DefaultAdminUser { get; } = new IdentityServerUser();

        public static string ClientId { get; } = string.Empty;
        public static string RedirectUri { get; } = string.Empty;

        static IdentityServerData()
        {
            Url = TestConfiguration.Configuration["baseUri"];
            EmailDomain = TestConfiguration.Configuration["emailDomain"];
            DefaultPassword = TestConfiguration.Configuration["defaultPassword"];

            TestConfiguration.Configuration.Bind(
                "defaultAdminUser",
                DefaultAdminUser
            );

            ClientId = TestConfiguration.Configuration["clientId"];
            RedirectUri = TestConfiguration.Configuration["redirectUri"];
        }
    }
}
