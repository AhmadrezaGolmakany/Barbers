using System.Security.Claims;
using Barber.Data.Context;
using Barber.Data.Entities.User;
using Barbers.Core.DTOs;
using Barbers.Core.Services.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using TopLearn.Core.Security;

namespace Barbers.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly BarbersContext _context;
        private IUserService _service;

        public AccountController(BarbersContext context, IUserService service)
        {
            _context = context;
            _service = service;
        }


        #region Register

        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }
        [Route("Register")]
        [HttpPost]
        public IActionResult Register(RegisterViewModel register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);

            }

            if (_service.IsExistEmail(register.Email))
            {
                ModelState.AddModelError("Email", "ایمیل وارد شده معتبر نمیباشد");
                return View(register);

            }

            if (_service.IsExistUserName(register.UserName))
            {
                ModelState.AddModelError("UserName", "ایمیل وارد شدع قبلا در سایت ثبت نام کرده است!");
                return View(register);
            }

            User user = new User()
            {
                FullName = register.FullName,
                Email = register.Email,
                password = PasswordHelper.EncodePasswordMd5(register.password),
                Phone = register.Phone,
                UserName = register.UserName,
                JoinDate = DateTime.Now

            };

            _service.AddUSer(user);
            return Redirect("/Login");
        }


        #endregion



        #region Login and Logout

        [Route("Login")]
        public IActionResult Login(bool EditeProfile = false)
        {
            ViewBag.EditeProfile = EditeProfile;

            return View();
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginViewModel login , string returnUrl="/")
        {
            if (!ModelState.IsValid)
            {
                return View();
            }


            var user = _service.LoginUser(login);

            if (user != null)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier,user.userId.ToString()),
                    new Claim(ClaimTypes.Email , user.Email),
                    new Claim(ClaimTypes.Name , user.UserName),
                   


                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties
                {
                    IsPersistent = login.RememberMe
                };
                HttpContext.SignInAsync(principal, properties);
                return Redirect(returnUrl);

            }
            else
            {
                ModelState.AddModelError("UserName", "کاربری با این نام کاربری یافت نشد");

            }

            return View(login);


        }


        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/Login");
        }




        #endregion



        #region Forgotepasseord

        [Route("ForgetPassword")]
        public IActionResult ForgetPassword()
        {
            return View();
        }

        [Route("ForgetPassword")]
        [HttpPost]
        public IActionResult ForgetPassword(ForgetPasswordViewModel forget)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            User user = _service.GetuserByEmail(forget.Email);
            if (user == null)
            {
                ModelState.AddModelError("Email" , "کاربری با این ایمیل یافت نشد");
            }
            
            _service.ChangePassword(forget.Email , forget.password);



            return Redirect("/");
        }

        #endregion


    }
}
