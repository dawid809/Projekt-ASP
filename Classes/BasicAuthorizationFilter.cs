using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Net.Http.Headers;
using Projekt_ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Projekt_ASP.Data
{
    public class BasicAuthorizationFilter : IAsyncAuthorizationFilter
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public BasicAuthorizationFilter([FromServices] UserManager<AppUser> userManager, [FromServices] SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            if (context.Filters.OfType<BasicAuthentication>().Any())
            {
                IHeaderDictionary requestHeader = context.HttpContext.Request.Headers;

                if (!requestHeader.Keys.Contains(HeaderNames.Authorization))
                {
                    context.Result = new UnauthorizedResult();
                }
                else
                {
                    string[] token = requestHeader.GetAuthentication();

                    if (await this.Validate(token[0], token[1]))
                    {
                        GenericIdentity identity = new(token[0]);
                        GenericPrincipal principal = new(identity, null);
                        Thread.CurrentPrincipal = principal;
                    }
                    else
                    {
                        context.Result = new UnauthorizedResult();
                    }
                }
            }
        }

        private async Task<Boolean> Validate(string userName, string password)
        {
            AppUser user = await userManager.FindByNameAsync(userName);

            if (user != null)
            {
                await this.signInManager.SignOutAsync();

                return (await signInManager.PasswordSignInAsync(user, password, false, false)).Succeeded;
            }
            return false;
        }
    }

    public static class HeaderDictionaryAuthentication
    {
        public static string[] GetAuthentication(this IHeaderDictionary requestHeader)
        {
            return Encoding.UTF8.GetString(
                    Convert.FromBase64String(
                        ((string)requestHeader[HeaderNames.Authorization])
                            .Split(" ")
                            .Last()
                            .Trim()))
                .Split(":");
        }
    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class BasicAuthentication : Attribute, IFilterMetadata { }
}

