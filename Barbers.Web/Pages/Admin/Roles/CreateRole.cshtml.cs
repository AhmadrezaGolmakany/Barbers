using Barbers.Core.Security;
using Barbers.Core.Services.Premition;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Barbers.Web.Pages.Admin.Role
{
    [PermitionChecker(6)]

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
            ViewData["Premitiom"] = _premitionService.GetAllPremitions();
        }

        public IActionResult OnPost(List<int> SelectedPermission)
        {

            

            Role.IsDelete = false;
           int roleid = _premitionService.AddRoel(Role);



            _premitionService.AddPremition(roleid , SelectedPermission);
           return Redirect("/Admin/Roles/Index");
        }
    }
}
    