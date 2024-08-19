using Barbers.Core.Services.Premition;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Barbers.Core.Security
{
    public class PermitionCheckerAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private IPremitionService _permissionService;
        private int _permissionId = 0;
        public PermitionCheckerAttribute(int permissionId)
        {
            _permissionId = permissionId;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _permissionService =
                (IPremitionService)context.HttpContext.RequestServices.GetService(typeof(IPremitionService));
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                string userName = context.HttpContext.User.Identity.Name;

                if (!_permissionService.CheckPermission(_permissionId, userName))
                {
                    context.Result = new RedirectResult("/Login");
                }
            }
            else
            {
                context.Result = new RedirectResult("/Login");
            }
        }
    }
}
