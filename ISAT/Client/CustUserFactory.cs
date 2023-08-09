using Microsoft.AspNetCore.Components.WebAssembly.Authentication.Internal;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System.Security.Claims;
using System.Text.Json;

namespace ISAT.Client
{
    // code according to 
    //https://learn.microsoft.com/en-us/aspnet/core/blazor/security/webassembly/hosted-with-identity-server?view=aspnetcore-7.0&tabs=visual-studio
    public class CustUserFactory : AccountClaimsPrincipalFactory<RemoteUserAccount>
    {
        public CustUserFactory(IAccessTokenProviderAccessor accessor)
            : base(accessor)
        {
        }

        public override async ValueTask<ClaimsPrincipal> CreateUserAsync(
            RemoteUserAccount account,
            RemoteAuthenticationUserOptions options)
        {
            var user = await base.CreateUserAsync(account, options);

            if ((user.Identity !=null) && (user.Identity.IsAuthenticated))
            {
                var identity = (ClaimsIdentity)user.Identity;
                
                //getting roles from Identity obj retrieved before from db by Identity component
                var roleClaims = identity.FindAll(identity.RoleClaimType).ToArray();

                if (roleClaims.Any())
                {
                    // cleaning roles before adding
                    foreach (var existingClaim in roleClaims)
                    {
                        identity.RemoveClaim(existingClaim);
                    }

                    var rolesElem =
                        account.AdditionalProperties[identity.RoleClaimType];

                    if ((options.RoleClaim != null) && (rolesElem is JsonElement roles))
                    {
                        if (roles.ValueKind == JsonValueKind.Array) // from  json format
                        {
                            foreach (var role in roles.EnumerateArray())
                            {
                                var roleValue = role.GetString();
                                
                                // adding after get from Database
                                if (!string.IsNullOrEmpty(roleValue))
                                {
                                    identity.AddClaim(
                                      new Claim(options.RoleClaim, roleValue));
                                }

                            }
                        }
                        else 
                        {
                            // from common format
                            var roleValue = roles.GetString();

                            if (!string.IsNullOrEmpty(roleValue))
                            {
                                identity.AddClaim(
                                  new Claim(options.RoleClaim, roleValue));
                            }
                        }
                    }
                }
            }

            return user;
        }
    }
}