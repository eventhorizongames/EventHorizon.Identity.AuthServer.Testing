namespace EventHorizon.Identity.AuthServer.Testing.Account.Tests
{
    using Atata;

    using EventHorizon.Identity.AuthServer.Testing.Core.Browser;
    using EventHorizon.Identity.AuthServer.Testing.Login.Pages;

    using Xunit;

    public class ShouldShowEmailAndPasswordErrorMessageWhenBothAreEmpty
        : WebHost
    {
        [Trait("Category", "Account Login Page")]
        [PrettyFact(nameof(ShouldShowEmailAndPasswordErrorMessageWhenBothAreEmpty))]
        public void Test()
        {
            this.Open<LoginPage>()
                .Email.Set(
                    string.Empty
                ).Password.Set(
                    string.Empty
                ).Login.Click()
                .EmailErrorByInput.Should.Equal(
                    "The Email field is required."
                ).PasswordErrorByInput.Should.Equal(
                    "The Password field is required."
                )
            ;
        }
    }
}
