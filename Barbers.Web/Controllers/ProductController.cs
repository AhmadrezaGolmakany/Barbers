using Barber.Data.Entities.Product;
using Barbers.Core.Services.Product;
using Microsoft.AspNetCore.Mvc;

namespace Barbers.Web.Controllers
{
    public class ProductController : Controller
    {

        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [BindProperty]
        public List<product> Products { get; set; }

        [Route("Store")]
        public IActionResult Index()
        {
            ViewBag.product = _productService.GetAllProduct();

            return View();
        }

     




      
    }
}
