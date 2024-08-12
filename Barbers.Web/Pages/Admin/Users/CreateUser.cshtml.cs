using Barbers.Core.DTOs;
using Barbers.Core.Services.Premition;
using Barbers.Core.Services.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Barbers.Web.Pages.Admin.Users
{
    public class CreateUserModel : PageModel
    {

        private readonly IPremitionService _premitionService;
        private readonly IUserService _userService;

        public CreateUserModel(IPremitionService premitionService, IUserService userService)
        {
            _premitionService = premitionService;
            _userService = userService;
        }

        [BindProperty]
        public CreateUserForAdmin Create { get; set; }


        public void OnGet()
        {
            ViewData["Roles"] = _premitionService.GetAllRoles();

        }

        public IActionResult OnPost(List<int> selectedrole)
        { 
           if (!ModelState.IsValid)
            {
                return Page();
            }

            int userId = _userService.AddUserForAdmin(Create);

            _premitionService.AddRoleUser(selectedrole , userId);

            return Redirect("/Admin/Users/Index");
        }
    }
}
