using Barbers.Core.DTOs;
using Barbers.Core.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Barbers.Web.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    [Authorize]
    public class WalletController : Controller
    {
        private readonly IUserService _userService;

        public WalletController(IUserService userService)
        {
            _userService = userService;
        }


        [Route("UserPanel/Wallet")]
        public IActionResult Index()
        {
            ViewBag.listWallet = _userService.GetUserWallet(User.Identity.Name);
            return View();
        }

        [Route("UserPanel/Wallet")]
        [HttpPost]
        public IActionResult Index(ChargeWalletViewModel charg)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.listWallet = _userService.GetUserWallet(User.Identity.Name);
                return View(charg);
            }

            int WalletId = _userService.ChargeWallet(User.Identity.Name, "شارژ حساب", charg.Amount);

            #region online payment

            var payment = new ZarinpalSandbox.Payment(charg.Amount);

            var res = payment.PaymentRequest("شارژ کیف پول", "https://localhost:7071/OnlinePayment/" + WalletId);

            if (res.Result.Status == 100)
            {
                return Redirect("https://sandbox.zarinpal.com/pg/StartPay/" + res.Result.Authority);
            }

            #endregion

            return null;
        }
    }
}
