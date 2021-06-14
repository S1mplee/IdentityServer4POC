using System.Collections.Generic;
using System.Security.Claims;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace IdentityServer
{
    public class IdentityConfiguration
    {
        public static List<TestUser> TestUsers =>
            new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "10",
                    Username = "aloulo",
                    Password = "aloulo123",
                    Claims =
                    {
                        new Claim(JwtClaimTypes.Name, "Ali Boumellessa"),
                        new Claim(JwtClaimTypes.GivenName, "Ali"),
                        new Claim(JwtClaimTypes.FamilyName, "Boumellessa"),
                        new Claim(JwtClaimTypes.WebSite, "http://google.com"),
                    }
                }
            };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("testApi.read"),
                new ApiScope("testApi.write"),
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new ApiResource("testApi")
                {
                    Scopes = new List<string>{ "testApi.read", "testApi.write" },
                    ApiSecrets = new List<Secret>{ new Secret("supersecret".Sha256()) }
                }
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = "cwm.client",
                    ClientName = "Client Credentials Client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedScopes = { "testApi.read" }
                },
            };
    }
}
