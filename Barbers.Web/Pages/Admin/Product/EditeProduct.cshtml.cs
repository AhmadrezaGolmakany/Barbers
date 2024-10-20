using Barbers.Core.DTOs;
using Barbers.Core.Services.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Barbers.Web.Pages.Admin.Product
{
    public class EditeProductModel : PageModel
    {
        private readonly IProductService _productService;

        public EditeProductModel(IProductService productService)
        {
            _productService = productService;
        }


        public EditeProductViewModel Model {
            get;
            set;
        }

        [Route("")]
        public void OnGet(int id)
        {
            Model = _productService.GetProductForEdite(id);
        }
    }
}
