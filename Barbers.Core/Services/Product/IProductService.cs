using Barber.Data.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbers.Core.Services.Product
{
    public interface IProductService
    {
        int AddProduct(product product);
    }
}
