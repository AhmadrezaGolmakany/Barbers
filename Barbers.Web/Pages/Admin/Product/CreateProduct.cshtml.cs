using Barber.Data.Entities.Product;
using Barbers.Core.DTOs;
using Barbers.Core.Services.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Barbers.Web.Pages.Admin.Product
{
    public class CreateProductModel : PageModel
    {

        private readonly IProductService _productService;

        public CreateProductModel(IProductService productService)
        {
            _productService = productService;
        }

        [BindProperty]
        public CreateProductViewModel create { get; set; }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) 
            {
                return Page();
            }

            product product = new()
            {
                Name = create.Name,
                Price = create.Price,
                Dscription = create.Dscription,
                CreateDate = DateTime.Now,
                IsDelete = false
            };
            _productService.AddProduct(product);
            return RedirectToPage("/admin/product/index");

        }
    }
}
