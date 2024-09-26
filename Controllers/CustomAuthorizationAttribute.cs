
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;

namespace RegisterAndLoginApp.Controllers
{
    internal class CustomAuthorizationAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            
            string userName = context.HttpContext.Session.GetString("username");
            
            if (userName == null)
            {
                // Session "username" variable is not set. Deny access by sending them to the login page.
                context.Result = new RedirectResult("/login");
            }
            else
            {
                // Do nothing, let the session proceed.             
            }

        }
    }
}