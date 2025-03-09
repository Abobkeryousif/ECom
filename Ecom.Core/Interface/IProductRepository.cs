using Ecom.Core.DTO;
using Ecom.Core.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Core.Interface
{
    public interface IProductRepository : IGenreicRepository<Product>
    {
       Task<bool> AddAsync(AddProductDto addProductDto);
    }
}
