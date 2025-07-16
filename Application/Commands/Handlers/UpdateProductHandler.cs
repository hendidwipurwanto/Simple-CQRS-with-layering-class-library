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
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, BaseResponse>
    {
        private readonly IProductService _productService;
        public UpdateProductHandler(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<BaseResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var existingProduct = await _productService.GetByIdAsync(request.Id);

            if (existingProduct == null)
                throw new ArgumentException($"Product with ID {request.Id} not found");

           
         
            var updatedProduct = await _productService.UpdateAsync(request.Id, request.productRequest);

            return updatedProduct;
        }
    }
}
