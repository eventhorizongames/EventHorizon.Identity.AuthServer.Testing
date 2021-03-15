namespace EventHorizon.Identity.AuthServer.Testing.Core.Browser.Model
{
    using EventHorizon.Identity.AuthServer.Testing.Core.Browser.Api;

    public class WebHostDriverModel
        : WebHostDriver
    {
        public string Type { get; set; }
        public WebHostDriverOptionsModel Options { get; set; } = new WebHostDriverOptionsModel();
        WebHostDriverOptions WebHostDriver.Options => Options;
    }
}
