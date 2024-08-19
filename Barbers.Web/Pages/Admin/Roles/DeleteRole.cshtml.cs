using Barbers.Core.Security;
using Barbers.Core.Services.Premition;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Barbers.Web.Pages.Admin.Roles
{
    [PermitionChecker(8)]

    public class DeleteRoleModel : PageModel
    {
        private readonly IPremitionService _premitionService;

        public DeleteRoleModel(IPremitionService premitionService)
        {
            _premitionService = premitionService;
        }

        [BindProperty]
        public Barber.Data.Entities.User.Role role { get; set; }


        public void OnGet(int id)
        {
            role = _premitionService.GetRoleByRoleId(id);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _premitionService.DeleteRole(role);
            return RedirectToPage("/Admin/Roles/Index");
        }

    }
}
