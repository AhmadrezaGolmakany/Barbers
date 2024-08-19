using System.Reflection;
using Barbers.Core.Security;
using Barbers.Core.Services.Premition;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Barbers.Web.Pages.Admin.Roles
{
    [PermitionChecker(7)]

    public class EditeRoleModel : PageModel
    {
        private readonly IPremitionService _premitionService;

        public EditeRoleModel(IPremitionService premitionService)
        {
            _premitionService = premitionService;
        }

        [BindProperty]
        public Barber.Data.Entities.User.Role role { get; set; }

        public void OnGet(int id )
        {
            role = _premitionService.GetRoleByRoleId(id);
            ViewData["Premitiom"] = _premitionService.GetAllPremitions();
            ViewData["SelectedPermissions"] = _premitionService.PermissionRoles(id);

        }

        public IActionResult OnPost(List<int> SelectedPermission)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _premitionService.UpdateRole(role);
            _premitionService.UpdatePemissions(role.RoleId , SelectedPermission);
            return RedirectToPage("/admin/roles/index");
        }
    }
}
