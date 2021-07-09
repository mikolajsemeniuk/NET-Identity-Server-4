using System;
using System.Collections.Generic;
using IdentityServer4.Models;

namespace Identity.Service
{
    public class Config
    {
        internal static IEnumerable<ApiScope> Scopes { get; set; } = new List<ApiScope>
        {
            new ApiScope
            {
                Name = "catalog.fullaccess",
            }
        };
        internal static IEnumerable<Client> Clients { get; set; } = new List<Client>
        {
            new Client
            {
                ClientId = "postman",
                AllowedGrantTypes = { "authorization_code" },
                RequireClientSecret = false,
                RedirectUris = { "urn:ietf:wg:oauth:2.0:oob" },
                AllowedScopes = { "openid", "profile", "catalog.fullaccess" },
                AlwaysIncludeUserClaimsInIdToken = true
            }
        };
        internal static IEnumerable<ApiResource> ApiResources { get; set; } = new List<ApiResource>
        {
            new ApiResource
            {
                Name = "catalog",
                Scopes = { "catalog.fullaccess" },
                UserClaims = { "role" }
            }
        };
        internal static IEnumerable<IdentityResource> Resources { get; set; } = new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile()
        };
        // internal static IReadOnlyCollection<IdentityResource> Resources =>
    }
}