namespace EventHorizon.Identity.AuthServer.Testing.Core.Browser.Api
{
    public interface WebHostDriver
    {
        string Type { get; }
        WebHostDriverOptions Options { get; }
    }
}
