using Barber.Data.Entities.Product;
using Barbers.Core.DTOs;
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

        ProductViewModel GetProductForAdmin(int pageId=1 , string nameFilter="" );
    }
}
