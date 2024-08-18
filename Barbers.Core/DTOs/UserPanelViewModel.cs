using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbers.Core.DTOs
{
    public class InfomationUserViewModel
    {
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string UserName { get; set; }

        public string Email { get; set; }

        public DateTime Joindate { get; set; }

        public int Wallet { get; set; }

        
    }


    public class EditeProfileUserViewModel
    {
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0}نمیتواند بیتر از {1}  کاراکتر باشد . ")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0}نمیتواند بیتر از {1}  کاراکتر باشد . ")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0}نمیتواند بیتر از {1}  کاراکتر باشد . ")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0}نمیتواند بیتر از {1}  کاراکتر باشد . ")]
        public string Email { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0}نمیتواند بیتر از {1}  کاراکتر باشد . ")]
        public string OldPassword { get; set; }


        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0}نمیتواند بیتر از {1}  کاراکتر باشد . ")]
        public string password { get; set; }


        [Compare("password", ErrorMessage = "کلمه عبور مغایرت دارد")]
        public string RePassword { get; set; }
    }
}
