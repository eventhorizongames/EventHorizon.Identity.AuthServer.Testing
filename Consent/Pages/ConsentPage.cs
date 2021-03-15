namespace EventHorizon.Identity.AuthServer.Testing.Consent.Pages
{
    using System.Collections.Generic;

    using Atata;

    using EventHorizon.Identity.AuthServer.Testing.Data;
    using EventHorizon.Identity.AuthServer.Testing.Layout;

    using _ = ConsentPage;

    public class ConsentPage
        : MainLayoutPage<_>
    {
        private const string responseType = "code";
        private const string scope = "openid profile email roles";
        private const string state = "fe737009777944db9de80baf370105a1";
        private const string codeChallenge = "_ubt4YbQ-7qU1tho4STnaDAG6RcRbKphIt3SH4mwq5c";
        private const string codeChallengeMethod = "S256";

        public static string Url(
            string clientId,
            string redirectUri
        ) => string.Join(
            string.Empty,
            new List<string>
            {
                "/connect/authorize",
                $"?client_id={clientId}",
                $"&redirect_uri={redirectUri}",
                $"&response_type={responseType}",
                $"&scope={scope}",
                $"&state={state}",
                $"&code_challenge={codeChallenge}",
                $"&code_challenge_method={codeChallengeMethod}",
            }
        );

        [FindById]
        public Button<_> Yes { get; private set; }

        [FindById]
        public Button<_> No { get; private set; }

        [FindBySelector("description")]
        public Text<_> Description { get; private set; }

        [FindBySelector("personal-info-heading")]
        public Text<_> PersonalInfoHeading { get; private set; }

        [FindBySelector("personal-info-scopes")]
        public ControlList<ScopeItem, _> PersonalInfoScopes { get; private set; }

        [FindBySelector("application-access-heading")]
        public Text<_> ApplicationAccessHeading { get; private set; }

        [FindBySelector("application-access-scopes")]
        public ControlList<ScopeItem, _> ApplicationAccessScopes { get; private set; }

        [FindBySelector("access-description-label")]
        public Text<_> AccessDescriptionLabel { get; private set; }
        [FindBySelector("access-description")]
        public TextInput<_> AccessDescription { get; private set; }

        [FindBySelector("remember-decision-label")]
        public Label<_> RememberDecisionLabel { get; private set; }
        [FindBySelector("remember-decision")]
        public CheckBox<_> RememberDecision { get; private set; }

        [FindById("client-url")]
        public Link<_> ClientUrl { get; private set; }

        [ControlDefinition("li", ContainingClass = "scope")]
        public class ScopeItem
            : Control<_>
        {
            [FindBySelector("scope-label")]
            public Text<_> Label { get; private set; }
        }
    }
}
