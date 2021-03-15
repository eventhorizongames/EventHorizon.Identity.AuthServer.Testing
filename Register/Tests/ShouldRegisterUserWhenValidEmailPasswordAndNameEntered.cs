namespace EventHorizon.Identity.AuthServer.Testing.Register.Tests
{
    using System;

    using Atata;

    using EventHorizon.Identity.AuthServer.Testing.Core.Browser;
    using EventHorizon.Identity.AuthServer.Testing.Data;
    using EventHorizon.Identity.AuthServer.Testing.Register.Pages;

    using Xunit;

    public class ShouldRegisterUserWhenValidEmailPasswordAndNameEntered
        : WebHost
    {
        [Trait("Category", "Register Page")]
        [PrettyFact(nameof(ShouldRegisterUserWhenValidEmailPasswordAndNameEntered))]
        public void Test()
        {
            var userId = Guid.NewGuid();
            var email = $"user_{userId}@{IdentityServerData.EmailDomain}";
            var password = IdentityServerData.DefaultPassword;
            CleanupActionList.Add(() => this.CleanupUser(email, password));

            Go.To<RegisterPage>()
                .Email.Set(email)
                .Password.Set(password)
                .ConfirmPassword.Set(password)
                .FirstName.Set("first name")
                .ServiceAgreements.Check()
                .Register.Click()
                .TopBar.LoginUserName.IsVisible.Should.BeTrue()
            ;
        }
    }
}
