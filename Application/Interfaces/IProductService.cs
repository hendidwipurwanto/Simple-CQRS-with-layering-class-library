using Domain.Entities;
using Domain.Models.DTOs;
using Domain.Models.Requests;
using Domain.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAllAsync();
        Task<ProductDto> GetByIdAsync(int id);
        Task<BaseResponse> CreateAsync(ProductRequest request);
        Task<BaseResponse> UpdateAsync(int id, ProductRequest request);
        Task<BaseResponse> DeleteAsync(int id);
    }
}
