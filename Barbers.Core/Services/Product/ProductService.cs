using Barber.Data.Context;
using Barber.Data.Entities.Product;
using Barbers.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbers.Core.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly BarbersContext _context;

        public ProductService(BarbersContext context)
        {
            _context = context;
        }

        

        public int AddProduct(product product)
        {
            _context.products.Add(product);
            _context.SaveChanges();
            return product.ProductId;
        }

        public ProductViewModel GetProductForAdmin(int pageId = 1, string nameFilter = "")
        {
            IQueryable<product> result = _context.products;

            if (!string.IsNullOrEmpty(nameFilter))
            {
                result = result.Where(p=>p.Name.Contains(nameFilter));
            }

            int take = 20;
            int skip = (pageId - 1) * take;


            ProductViewModel list = new ProductViewModel();

            list.CurrentPage = pageId;
            list.PageCount = result.Count() / take;

            list.products = result.OrderBy(p => p.Name).Skip(skip).Take(take).ToList();

            return list;


        }
    }
}
