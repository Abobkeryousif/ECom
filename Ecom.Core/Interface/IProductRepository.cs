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

        Task<List<Product>> GetAllAsync(string? filterOn = null,string? filterQuery = null,string? sortBy = null,bool isAscending = true
            ,int pageNumber = 1,int pageSize = 30);
        Task<bool> AddAsync(AddProductDto addProductDto);
        Task<bool> UpdateAsync(UpdateProductDto updateProductDto);
        Task DeleteAsyncs(Product product);
    }
}
