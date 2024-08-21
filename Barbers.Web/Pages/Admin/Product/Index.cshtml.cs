using Barbers.Core.DTOs;
using Barbers.Core.Services.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Barbers.Web.Pages.Admin.Product
{
    public class IndexModel : PageModel
    {

        private readonly IProductService _productService;

        public IndexModel(IProductService productService)
        {
            _productService = productService;
        }


        public ProductViewModel product { get; set; }


        public void OnGet(int pageId=1 , string filtername="")
        {
            product = _productService.GetProductForAdmin(pageId,filtername);
        }
    }
}
