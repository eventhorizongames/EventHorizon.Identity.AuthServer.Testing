namespace EventHorizon.Identity.AuthServer.Testing.Core.Browser
{
    using System;
    using Atata;
    using EventHorizon.Identity.AuthServer.Testing.Data;
    using EventHorizon.Identity.AuthServer.Testing.Models;
    using EventHorizon.Identity.AuthServer.Testing.Layout;
    using EventHorizon.Identity.AuthServer.Testing.Login.Pages;
    using EventHorizon.Identity.AuthServer.Testing.Logout.Pages;
    using EventHorizon.Identity.AuthServer.Testing.Register.Pages;
    using EventHorizon.Identity.AuthServer.Testing.Manage.Pages;

    public static class WebHostExtensions
    {
        public static TOwner Login<TOwner>(
            this WebHost _,
            IdentityServerUser user
        ) where TOwner : PageObject<TOwner>, ILayoutPage<TOwner>
        {
            Go.To<LoginPage>()
                .Email.Set(
                    user.Email
                ).Password.Set(
                    user.Password
                ).Login.Click();

            return Go.To<TOwner>();
        }

        public static WebHost Login(
            this WebHost webHost,
            IdentityServerUser user
        )
        {
            Go.To<LoginPage>()
                .Email.Set(
                    user.Email
                ).Password.Set(
                    user.Password
                ).Login.Click();

            return webHost;
        }

        public static TOwner LoginWithAdmin<TOwner>(
            this WebHost _
        ) where TOwner : PageObject<TOwner>, ILayoutPage<TOwner>
        {
            Go.To<LoginPage>()
                .Email.Set(
                    IdentityServerData.DefaultAdminUser.Email
                ).Password.Set(
                    IdentityServerData.DefaultAdminUser.Password
                ).Login.Click();

            return Go.To<TOwner>();
        }

        public static WebHost LoginWithAdmin(
            this WebHost webHost
        )
        {
            Go.To<LoginPage>()
                .Email.Set(
                    IdentityServerData.DefaultAdminUser.Email
                ).Password.Set(
                    IdentityServerData.DefaultAdminUser.Password
                ).Login.Click();

            return webHost;
        }

        public static TOwner Logout<TOwner>(
            this PageObject<TOwner> _
        ) where TOwner : PageObject<TOwner>, ILayoutPage<TOwner>
        {
            return Go.To<LogoutPage>()
                .Yes.ClickAndGo<TOwner>()
            ;
        }

        public static TOwner LoginWithNewUser<TOwner>(
            this WebHost webHost,
            out IdentityServerUser user
        ) where TOwner : PageObject<TOwner>, ILayoutPage<TOwner>
        {
            var userId = Guid.NewGuid();
            var email = $"user_{userId}@{IdentityServerData.EmailDomain}";
            var password = IdentityServerData.DefaultPassword;
            user = new IdentityServerUser
            {
                Email = email,
                Password = password,
                FirstName = $"User ({userId})",
            };
            webHost.CleanupActionList.Add(() => webHost.CleanupUser(email, password));

            // Should Redirect to Identity Server Login Page
            Go.To<LoginPage>()
                .RegisterNewUser
                .ClickAndGo<RegisterPage>()
                .Email.Set(
                    user.Email
                ).Password.Set(
                    user.Password
                ).ConfirmPassword.Set(
                    user.Password
                ).FirstName.Set(
                    user.FirstName
                ).ServiceAgreements.Check()
                .Register.Click()
                .TopBar.LoginUserName.IsVisible.Should.BeTrue();

            Go.To<LogoutPage>().Yes.Click();

            return Login<TOwner>(
                webHost,
                user
            );
        }

        public static WebHost LoginWithNewUser(
            this WebHost webHost,
            out IdentityServerUser user
        )
        {
            var userId = Guid.NewGuid();
            var email = $"user_{userId}@{IdentityServerData.EmailDomain}";
            var password = IdentityServerData.DefaultPassword;
            user = new IdentityServerUser
            {
                Email = email,
                Password = password,
                FirstName = $"User ({userId})",
            };
            webHost.CleanupActionList.Add(() => webHost.CleanupUser(email, password));

            // Should Redirect to Identity Server Login Page
            Go.To<LoginPage>()
                .RegisterNewUser
                .ClickAndGo<RegisterPage>()
                .Email.Set(
                    user.Email
                ).Password.Set(
                    user.Password
                ).ConfirmPassword.Set(
                    user.Password
                ).FirstName.Set(
                    user.FirstName
                ).ServiceAgreements.Check()
                .Register.Click()
                .TopBar.LoginUserName.IsVisible.Should.BeTrue();

            Go.To<LogoutPage>().Yes.Click();

            return Login(
                webHost,
                user
            );
        }

        public static void CleanupUser(
            this WebHost _,
            string email,
            string password
        )
        {
            try
            {
                Go.To<LoginPage>()
                    .Email.Set(
                        email
                    ).Password.Set(
                        password
                    ).Login.Click();

                Go.To<ManagePurgeAccountPage>()
                    .Confirm.Click();
            }
            catch { }
        }
    }
}
