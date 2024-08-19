using System.Reflection;
using Barbers.Core.Services.Premition;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Barbers.Web.Pages.Admin.Roles
{
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
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _premitionService.UpdateRole(role);
            return RedirectToPage("/index");
        }
    }
}
