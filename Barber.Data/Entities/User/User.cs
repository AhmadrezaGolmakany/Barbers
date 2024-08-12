using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barber.Data.Entities.User
{
    public class User
    {
        [Key]
        public int userId { get; set; }

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

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0}نمیتواند بیتر از {1}  کاراکتر باشد . ")]
        public string password { get; set; }


        public DateTime JoinDate { get; set; }

        public bool IsDelete { get; set; }


        #region Realation

        public List<Wallet.Wallet> Wallets { get; set; }
        public virtual List<UserRole> userRoles { get; set; }
        


        #endregion





    }
}
