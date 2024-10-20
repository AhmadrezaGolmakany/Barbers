using Barber.Data.Entities.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbers.Core.DTOs
{
    public class ProductViewModel
    {
        public List<product> products    { get; set; }

        public int CurrentPage { get; set; }

        public int PageCount { get; set; }
    }

    public class CreateProductViewModel
    {
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "{0}نمیتواند بیتر از {1}  کاراکتر باشد . ")]
        public string Name { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(500, ErrorMessage = "{0}نمیتواند بیتر از {1}  کاراکتر باشد . ")]
        public string Dscription { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Price { get; set; }
    }

    public class EditeProductViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "{0}نمیتواند بیتر از {1}  کاراکتر باشد . ")]
        public string Name { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(500, ErrorMessage = "{0}نمیتواند بیتر از {1}  کاراکتر باشد . ")]
        public string Dscription { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Price { get; set; }
    }
}
