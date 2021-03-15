namespace EventHorizon.Identity.AuthServer.Testing.Grants.Pages
{

    using Atata;

    using EventHorizon.Identity.AuthServer.Testing.Layout;

    using _ = GrantsPage;

    [Url("/Grants")]
    public class GrantsPage
        : MainLayoutPage<_>
    {
        public ControlList<GrantItem, _> Grants { get; private set; }

        [ControlDefinition("div", ContainingClass = "grant")]
        public class GrantItem
            : Control<_>
        {
            [FindByClass("clientname")]
            public Text<_> ClientName { get; private set; }

            [FindBySelector("created-label")]
            public Text<_> CreatedLabel { get; private set; }
            [FindBySelector("created")]
            public Text<_> Created { get; private set; }

            [FindBySelector("created-label")]
            public Text<_> ExpiresLabel { get; private set; }
            [FindBySelector("expires")]
            public Text<_> Expires { get; private set; }

            [FindBySelector("granttype_identity-label")]
            public Text<_> IdentityGrantTypesLabel { get; private set; }
            [FindBySelector("granttype_identity")]
            public ControlList<IdentityGrantTypeItem, _> IdentityGrantTypes { get; private set; }

            [FindBySelector("granttype_api-label")]
            public Text<_> ApiGrantTypesLabel { get; private set; }
            [FindBySelector("granttype_api")]
            public ControlList<ApiGrantTypeItem, _> ApiGrantTypes { get; private set; }

            [FindBySelector("revoke")]
            public Button<_> Revoke { get; private set; }

            [ControlDefinition("li", ContainingClass = "granttype_identity_item")]
            public class IdentityGrantTypeItem
                : Control<_>
            {
                [FindBySelector("name")]
                public Text<_> Label { get; private set; }
            }

            [ControlDefinition("li", ContainingClass = "granttype_api_item")]
            public class ApiGrantTypeItem
                : IdentityGrantTypeItem
            {
            }
        }
    }
}
