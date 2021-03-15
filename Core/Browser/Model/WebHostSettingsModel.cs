namespace EventHorizon.Identity.AuthServer.Testing.Core.Browser.Model
{
    using EventHorizon.Identity.AuthServer.Testing.Core.Browser.Api;

    public class WebHostSettingsModel
        : WebHostSettings
    {
        public string BaseUrl { get; set; }
        public string Culture { get; set; }
        public WebHostDriverModel Driver { get; set; } = new WebHostDriverModel();
        WebHostDriver WebHostSettings.Driver => Driver;
    }
}
