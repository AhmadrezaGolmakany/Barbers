using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barber.Data.Entities.Product
{
    public class product
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "{0}نمیتواند بیتر از {1}  کاراکتر باشد . ")]
        public string Name { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(500, ErrorMessage = "{0}نمیتواند بیتر از {1}  کاراکتر باشد . ")]
        public string Dscription { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(25, ErrorMessage = "{0}نمیتواند بیتر از {1}  کاراکتر باشد . ")]
        public double Price { get; set; }


        public bool IsDelete { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime DeleteDate   { get; set; }




    }
}
