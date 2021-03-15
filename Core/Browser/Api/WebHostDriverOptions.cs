namespace EventHorizon.Identity.AuthServer.Testing.Core.Browser.Api
{
    using System.Collections.Generic;

    public interface WebHostDriverOptions
    {
        IEnumerable<string> Arguments { get; }
    }
}
