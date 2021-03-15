namespace EventHorizon.Identity.AuthServer.Testing.Core.Browser.Model
{
    using System.Collections.Generic;
    using EventHorizon.Identity.AuthServer.Testing.Core.Browser.Api;

    public class WebHostDriverOptionsModel
        : WebHostDriverOptions
    {
        public List<string> Arguments { get; set; } = new List<string>();
        IEnumerable<string> WebHostDriverOptions.Arguments => Arguments;
    }
}
