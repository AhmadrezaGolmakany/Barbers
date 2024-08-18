using Barbers.Core.DTOs;
using Barbers.Core.Services.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Barbers.Web.Pages.Admin.Users
{
    public class ListeDeleteUserModel : PageModel
    {

        private readonly IUserService _userService;

        public ListeDeleteUserModel(IUserService userService)
        {
            _userService = userService;
        }


        public UserForAdminViewModel UserForAdminViewModel { get; set; }


        public void OnGet(int pageId = 1, string filteremail = "", string filterusername = "")
        {
            UserForAdminViewModel = _userService.GetDeleteUser(pageId, filteremail, filterusername);
        }

       
    }
}
