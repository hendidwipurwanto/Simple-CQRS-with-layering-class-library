using Application.Interfaces;
using Domain.Models.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, BaseResponse>
    {
        private readonly IProductService _productService;
        public CreateProductCommandHandler(IProductService productService)
        {
              _productService = productService;
        }
        public async Task<BaseResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            // Call the CreateAsync method of the product service
            return await _productService.CreateAsync(request.productRequest);
        }

    }
}
