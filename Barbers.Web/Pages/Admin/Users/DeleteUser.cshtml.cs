using Barbers.Core.DTOs;
using Barbers.Core.Services.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Barbers.Web.Pages.Admin.Users
{
    public class DeleteUserModel : PageModel
    {
        private readonly IUserService _userService;

        public DeleteUserModel(IUserService userService)
        {
            _userService = userService;
        }

        public InfomationUserViewModel UserViewModel { get; set; }

        public void OnGet(int id)
        {
            ViewData["UserId"] = id;
            UserViewModel = _userService.getInformationUserForAdmin(id);
        }

        public IActionResult OnPost(int userId)
        {
            _userService.DeleteUser(userId);

            return Redirect("/Admin/Users/Index");
        }
    }
}
