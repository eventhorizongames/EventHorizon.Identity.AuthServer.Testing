namespace EventHorizon.Identity.AuthServer.Testing.Layout
{
    using System;
    using Atata;

    public class TopBarComponent<TNavigateTo>
        : Control<TNavigateTo>
            where TNavigateTo : PageObject<TNavigateTo>
    {
        // TODO: Update AuthServer with specific 
        [FindByCss(".navbar-nav .dropdown .dropdown-toggle")]
        public Text<TNavigateTo> LoginUserName { get; private set; }

        [FindBySelector("site-brand")]
        public Link<TNavigateTo> SiteBrand { get; private set; }
    }
}
