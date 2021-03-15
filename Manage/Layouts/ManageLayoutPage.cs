namespace EventHorizon.Identity.AuthServer.Testing.Manage.Layouts
{
    using System;

    using Atata;

    using EventHorizon.Identity.AuthServer.Testing.Layout;

    public class ManageLayoutPage<TOwner>
        : MainLayoutPage<TOwner> where TOwner : Page<TOwner>
    {
        [FindById("page-details")]
        public Text<TOwner> PageDetails { get; private set; }

        public ManageSideBarComponent<TOwner> SideBar { get; private set; }
    }
}
