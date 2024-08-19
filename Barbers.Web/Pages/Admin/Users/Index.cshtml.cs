using Barbers.Core.DTOs;
using Barbers.Core.Security;
using Barbers.Core.Services.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Barbers.Web.Pages.Users
{
    [PermitionChecker(1)]

    public class IndexModel : PageModel
    {
        private readonly IUserService _userService;

        public IndexModel(IUserService userService)
        {
            _userService = userService;
        }

        public UserForAdminViewModel UserForAdminViewModel { get; set; }
        public void OnGet(int pageId = 1, string filteremail = "", string filterusername = "")
        {
            UserForAdminViewModel = _userService.getSUserForAdmin(pageId, filteremail, filterusername);

        }
    }
}
