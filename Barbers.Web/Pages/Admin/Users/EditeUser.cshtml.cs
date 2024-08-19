using Barbers.Core.DTOs;
using Barbers.Core.Security;
using Barbers.Core.Services.Premition;
using Barbers.Core.Services.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Barbers.Web.Pages.Admin.Users
{
    [PermitionChecker(4)]

    public class EditeUserModel : PageModel
    {
        private readonly IUserService _userService;

        private readonly IPremitionService _premitionService;

        public EditeUserModel(IUserService userService, IPremitionService premitionService)
        {
            _userService = userService;
            _premitionService = premitionService;
        }

        [BindProperty]
        public EditeUserFromAdminViewModel Edite { get; set; }



        public void OnGet(int id)
        {
            ViewData["Role"] = _premitionService.GetAllRoles(); 
            Edite = _userService.getUserForEdite(id);
        }

        public IActionResult OnPost(List<int> selectesRole)
        {
            if(!ModelState.IsValid)
                return Page() ;

            _userService.EditeUserFromAdmin(Edite);

            _premitionService.EditeUserRole(Edite.UserId, selectesRole);

            return Redirect("Index");
        }

    }
}
