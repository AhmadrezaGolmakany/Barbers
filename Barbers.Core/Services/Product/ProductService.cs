using Barber.Data.Context;
using Barber.Data.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbers.Core.Services.Product
{
    internal class ProductService : IProductService
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
    }
}
