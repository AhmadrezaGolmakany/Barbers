using Barbers.Core.Services.Premition;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Barbers.Web.Pages.Admin.Role
{
    public class CreateRoleModel : PageModel
    {
        private readonly IPremitionService _premitionService;

        public CreateRoleModel(IPremitionService premitionService)
        {
            _premitionService = premitionService;
        }


        [BindProperty]
        public Barber.Data.Entities.User.Role Role { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            Role.IsDelete = false;
           int roleid = _premitionService.AddRoel(Role);
           return Redirect("/Admin/Roles/Index");
        }
    }
}
    