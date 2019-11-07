using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PeterTodoApi.Contexts;
using PeterTodoApi.Interfaces;
using PeterTodoApi.Models;

namespace PeterTodoApi.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly DefaultContext _context;

        public ProductsRepository(DefaultContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductItem>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<ProductItem> GetProductAsync(int productId)
        {
            return await _context.Products.Where(p => p.ProductId == productId).
                            FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ProductItem>> FindProductsAsync(string sku)
        {
            return await _context.Products.Where(p => p.Sku.Contains(sku)).ToListAsync();
        }

        public async Task<ProductItem> DeleteProductAsync(int productId)
        {
            ProductItem product = await GetProductAsync(productId);

            if (product != null)
            {
                _context.Products.Remove(product);

                await _context.SaveChangesAsync();
            }

            return product;
        }
    }
}
