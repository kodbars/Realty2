using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace RealtyWeb_Server.Controllers
{
    public class CookieAuthenticationEvents : Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents
    {
        //private readonly IUsers _user; В книге указано, что такой подход используется для реальных проектов для проверк существования пользователя

        //public CookieAuthenticationEvents(IUsers user)
        //{
        //    _user = user;
        //}

        public override async Task ValidatePrincipal(CookieValidatePrincipalContext context) 
        {
            var userPrintical = context.Principal;
            if (userPrintical?.Identity?.Name?.ToLower() != "admin")
            {
                context.RejectPrincipal();
                await context.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
        }
    }
}
