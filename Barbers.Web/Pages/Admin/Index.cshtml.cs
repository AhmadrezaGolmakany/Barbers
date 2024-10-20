using Barber.Data.Entities.Product;
using Barbers.Core.DTOs;
using Barbers.Core.Services.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Barbers.Web.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private readonly IProductService _productService;

  

        public void OnGet()
        {
           
        }
    }
}
