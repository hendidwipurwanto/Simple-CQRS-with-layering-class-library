using Application.Interfaces;
using Domain.Entities;
using Domain.Models.DTOs;
using Domain.Models.Requests;
using Domain.Models.Responses;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<BaseResponse> CreateAsync(ProductRequest request)
        {
            var product = new Product() { Name = request.Name,
                Price = request.Price,
                Description = request.Description,
                CreatedAt=DateTime.Now  };

            await _productRepository.CreateAsync(product);
            var response = new BaseResponse
            {
                 StatusCode = 200,
                Message = "Product created successfully"
            };

            return response;
        }

        public  async Task<BaseResponse> DeleteAsync(int id)
        {
            var response = new BaseResponse();
            var isDeleted = await _productRepository.DeleteAsync(id);
            // Check if the product was deleted successfully
            if (isDeleted)
            {
                response.StatusCode = 200; // OK
                response.Message = "Product deleted successfully";
            }
            else
            {
                response.StatusCode = 404; // Not Found
                response.Message = "Product not found";
            }
            return response;
        }

        public async Task<List<ProductDto>> GetAllAsync()
        {
            // Fetch all products from the repository
            var products = await _productRepository.GetAllAsync();
            // Map the products to ProductDto
            var productDtos = products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Description = p.Description,
                CreatedAt = p.CreatedAt,
                UpdatedAt = p.UpdatedAt
            }).ToList();

            return productDtos;
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            // Fetch the product by ID from the repository
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return null; // or throw an exception if preferred
            }
            // Map the product to ProductDto
            var productDto = new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                CreatedAt = product.CreatedAt,
                UpdatedAt = product.UpdatedAt
            };

            return productDto;
        }

        public async Task<BaseResponse> UpdateAsync(int id, ProductRequest request)
        {
            var oldProduct = await _productRepository.GetByIdAsync(id);
            var response = new BaseResponse();
            if(oldProduct != null)
            {
                oldProduct.Price = request.Price;
                oldProduct.Description = request.Description;
                oldProduct.Name = request.Name;
                var product = await _productRepository.UpdateAsync(oldProduct);
                response.StatusCode = 200;
                response.Message = "Update Product Successfully";

            }
            return response;
           
        }
    }
}
