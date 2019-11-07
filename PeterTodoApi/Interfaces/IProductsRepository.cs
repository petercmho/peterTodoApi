using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PeterTodoApi.Models;

namespace PeterTodoApi.Interfaces
{
    public interface IProductsRepository
    {
        Task<IEnumerable<ProductItem>> GetAllProductsAsync();
        Task<ProductItem> GetProductAsync(int productId);
        Task<IEnumerable<ProductItem>> FindProductsAsync(string sku);
        Task<ProductItem> DeleteProductAsync(int productId);
    }
}
