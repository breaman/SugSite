using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;

namespace SugSite.Web.Configuration
{
    public static class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "angular",
                    ClientName = "Javascript Client",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,

                    RequireConsent = false,

                    RedirectUris = {"http://localhost:5000", "http://localhost:5000/callback"},
                    PostLogoutRedirectUris = {"http://localhost:5000"},

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "api1",
                        "role"
                    }
                }
            };
        }
    }
}