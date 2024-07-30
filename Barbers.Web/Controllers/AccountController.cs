using Microsoft.AspNetCore.Mvc;

namespace Barbers.Web.Controllers
{
    public class AccountController : Controller
    {
        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }
        //[Route("Register")]
        //[HttpPost]
        //public IActionResult Register()
        //{
        //    return View();
        //}
    }
}
