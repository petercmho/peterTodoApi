﻿using Microsoft.AspNetCore.Mvc;
using PeterTodoApi.Interfaces;
using PeterTodoApi.Models;
using PeterTodoApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeterTodoApi.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task<IActionResult> FindProductsAsync(string sku)
        {
            try
            {
                IEnumerable<ProductItem> products = await _productsRepository.FindProductsAsync(sku);

                if (products != null)
                {
                    return new OkObjectResult(products.Select(p => new ProductViewModel()
                    {
                        Id = p.ProductId,
                        Sku = p.Sku.Trim(),
                        Name = p.Name.Trim()
                    }));
                }
                else
                {
                    return new NotFoundResult();
                }
            }
            catch
            {
                return new ConflictResult();
            }
        }

        public async Task<IActionResult> GetAllProductsAsync()
        {
            try
            {
                IEnumerable<ProductItem> products = await _productsRepository.GetAllProductsAsync();

                if (products != null)
                {
                    return new OkObjectResult(products.Select(p => new ProductViewModel()
                    {
                        Id = p.ProductId,
                        Sku = p.Sku.Trim(),
                        Name = p.Name.Trim()
                    }));
                }
                else
                {
                    return new NotFoundResult();
                }
            }
            catch
            {
                return new ConflictResult();
            }
        }

        public async Task<IActionResult> GetProductAsync(int productId)
        {
            try
            {
                ProductItem product = await _productsRepository.GetProductAsync(productId);

                if (product != null)
                {
                    return new OkObjectResult(new ProductViewModel()
                    {
                        Id = product.ProductId,
                        Sku = product.Sku.Trim(),
                        Name = product.Name.Trim()
                    });
                }
                else
                {
                    return new NotFoundResult();
                }
            }
            catch
            {
                return new ConflictResult();
            }
        }

        public async Task<IActionResult> DeleteProductAsync(int productId)
        {
            try
            {
                ProductItem product = await _productsRepository.DeleteProductAsync(productId);

                if (product != null)
                {
                    return new OkObjectResult(new ProductViewModel()
                    {
                        Id = product.ProductId,
                        Sku = product.Sku.Trim(),
                        Name = product.Name.Trim()
                    });
                }
                else
                {
                    return new NotFoundResult();
                }
            }
            catch
            {
                return new ConflictResult();
            }
        }
    }
}
