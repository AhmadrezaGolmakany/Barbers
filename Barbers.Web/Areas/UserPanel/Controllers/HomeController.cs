using Barber.Data.Entities;
using Barbers.Core.DTOs;
using Barbers.Core.Services.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Barbers.Web.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    [Authorize]
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


        #region EditeProfile

        [Route("/UserPanel/EditeProfile")]
        public IActionResult EditeProfile()
        {
            return View(_userService.GetDataForEdite(User.Identity.Name));
        }

        [Route("UserPanel/EditeProfile")]
        [HttpPost]
        public IActionResult EditeProfile(EditeProfileUserViewModel edite)
        {
            if (!ModelState.IsValid)
            {
                return View(edite);
            }
            _userService.EditeProfile(edite, User.Identity.Name);

            ViewBag.IsSuccess = true;




            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);


            return Redirect("/Login?EditeProfile=true");
        }
        #endregion


        #region ChangePassword
        [Route("UserPanel/ChangePassword")]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [Route("UserPanel/ChangePassword")]
        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordViewModel pass )
        {
            var user = _userService.GetUserByUserName(User.Identity.Name);
            var emailuser = user.Email;
            if (!ModelState.IsValid)
            {
                return View(pass);

            }

            if (_userService.ComparePassword(pass.OldPassword , emailuser))
            {
                ModelState.AddModelError("OldPassword" , "کلمه عبور صحیح نمیباشد");
            }

            _userService.ComparePassword(pass.OldPassword, user.UserName);
            ViewBag.IsSuccess = true;



            return View(); 


        }

            #endregion


        }







}
