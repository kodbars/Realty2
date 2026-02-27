using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace RealtyWeb_Client.Utils
{
    public class SpecialAuthenticationStateProvider : AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var anonymousIdentity = new ClaimsIdentity();
            var anonymousPrincipal = new ClaimsPrincipal(anonymousIdentity);
            return await Task.FromResult(new AuthenticationState(anonymousPrincipal));

        }
    }
}
