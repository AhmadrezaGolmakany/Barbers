using Barber.Data.Context;
using Barber.Data.Entities;
using Barbers.Core.DTOs;
using Barbers.Core.Services.User;
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

            Barber.Data.Entities.User user = new User()
            {
                FullName = register.FullName,
                Email = register.Email,
                password = PasswordHelper.EncodePasswordMd5(register.password),
                Phone = register.Phone,
                UserName = register.UserName

            };

            _service.AddUSer(user);
            return Redirect("Index");
        }


        #endregion



        #region Login and Logout

        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }




        #endregion


    }
}
