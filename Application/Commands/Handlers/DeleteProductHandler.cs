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
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, BaseResponse>
    {
        private readonly IProductService _productService;
        public DeleteProductHandler(IProductService productService)
        {
            _productService = productService;
        }
        public Task<BaseResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var existingProduct = _productService.GetByIdAsync(request.Id).Result;
            if (existingProduct == null)
                throw new ArgumentException($"Product with ID {request.Id} not found");
            return _productService.DeleteAsync(request.Id);

        }
    }
}
