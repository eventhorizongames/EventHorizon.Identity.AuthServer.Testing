namespace EventHorizon.Identity.AuthServer.Testing.Manage.Tests
{
    using Atata;

    using EventHorizon.Identity.AuthServer.Testing.Core.Browser;
    using EventHorizon.Identity.AuthServer.Testing.Manage.Pages;

    using Xunit;

    public class ShouldSuccessfullyUpdateUserWhenSaveClicked
        : WebHost
    {
        [Trait("Category", "Manage Page")]
        [PrettyFact(nameof(ShouldSuccessfullyUpdateUserWhenSaveClicked))]
        public void Test()
        {
            this.LoginWithNewUser<ManagePage>(out var _)
                .SideBar.Profile.Click()
                    .FirstName.Set("First name")
                    .LastName.Set("Last name")
                    .PhoneNumber.Set("1 123-1234")
                    .Save.Click()
                    .StatusMessage.Should.Contain("Your profile has been updated")
            ;
        }
    }
}
