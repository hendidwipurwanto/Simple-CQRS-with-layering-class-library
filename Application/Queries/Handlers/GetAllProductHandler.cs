using Application.Interfaces;
using Domain.Models.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Handlers
{
    public class GetAllProductHandler : IRequestHandler<GetAllProductQuery, List<ProductDto>>
    {
        private readonly IProductService _productService;
        public GetAllProductHandler(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<List<ProductDto>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            return await _productService.GetAllAsync();
        }
    }
}
