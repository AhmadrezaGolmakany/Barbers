using Barber.Data.Entities.Premition;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barber.Data.Entities.User
{
    public class Role
    {
        public Role()
        {
            
        }

        [Key]
        public int RoleId { get; set; }

        [Display(Name = "نام نقش")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(200, ErrorMessage = "{0}نمیتواند بیتر از {1}  کاراکتر باشد . ")]
        public string RorleTitel { get; set; }
        public bool IsDelete { get; set; }


        #region relation

        public static  List<UserRole> userroles { get; set; }
        public static List<RolePremition> rolePremitions { get; set; }

        public static List<Premition.Premitions> premitions { get; set; }

        #endregion

    }
}
