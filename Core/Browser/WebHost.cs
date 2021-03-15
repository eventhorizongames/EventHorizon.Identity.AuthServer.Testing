namespace EventHorizon.Identity.AuthServer.Testing.Core.Browser
{
    using System;
    using System.Collections.Generic;

    using Atata;

    using EventHorizon.Identity.AuthServer.Testing.Core.Browser.Api;
    using EventHorizon.Identity.AuthServer.Testing.Core.Browser.Model;
    using EventHorizon.Identity.AuthServer.Testing.Core.Config;
    using EventHorizon.Identity.AuthServer.Testing.Layout;
    using EventHorizon.Identity.AuthServer.Testing.Models;

    using Microsoft.Edge.SeleniumTools;
    using Microsoft.Extensions.Configuration;

    using Xunit;

    public class WebHost
        : IClassFixture<AutomationWebHostFixture>,
        IDisposable
    {
        internal IList<Action> CleanupActionList { get; } = new List<Action>();

        public void Dispose()
        {
            foreach (var cleanupAction in CleanupActionList)
            {
                try { cleanupAction(); } catch { }
            }
        }

        public TOwner Open<TOwner>()
            where TOwner : PageObject<TOwner>, ILayoutPage<TOwner>
        {
            return Go.To<TOwner>()
                .Do(page =>
                {
                    if (page.CookieBanner.AcceptAndClose.IsVisible)
                    {
                        // Automatically Close the CookieBanner
                        page.CookieBanner.AcceptAndClose.Click();
                    }
                }
            );
        }

        public TOwner Open<TOwner>(
            string url
        ) where TOwner : PageObject<TOwner>, ILayoutPage<TOwner>
        {
            return Go.To<TOwner>(
                url: url
            ).Do(page =>
            {
                if (page.CookieBanner.AcceptAndClose.IsVisible)
                {
                    // Automatically Close the CookieBanner
                    page.CookieBanner.AcceptAndClose.Click();
                }
            });
        }
    }

    public class AutomationWebHostFixture
        : IDisposable
    {
        private static readonly WebHostSettings Settings = new WebHostSettingsModel();

        static AutomationWebHostFixture()
        {
            TestConfiguration.Configuration.Bind(
                "webHost",
                Settings
            );
        }

        public AutomationWebHostFixture()
        {
            AtataContext.Configure()
                .UseBaseUrl(
                    Settings.BaseUrl
                ).UseCulture(
                    Settings.Culture
                ).UseDriver(
                    () =>
                    {
                        EdgeOptions options = new EdgeOptions
                        {
                            UseChromium = true,
                            LeaveBrowserRunning = true,
                        };

                        foreach (var argument in Settings.Driver.Options.Arguments)
                        {
                            options.AddArgument(
                                argument
                            );
                        }

                        return new EdgeDriver(
                            AppDomain.CurrentDomain.BaseDirectory,
                            options
                        );
                    }
                ).Build();
        }

        public void Dispose()
        {
            AtataContext.Current?.CleanUp();
        }
    }
}
