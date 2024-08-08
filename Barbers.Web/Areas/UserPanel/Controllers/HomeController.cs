using Barbers.Core.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace Barbers.Web.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    public class HomeController : Controller
    {
        private readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View(_userService.getInformationUser(User.Identity.Name));
        }
    }
}
