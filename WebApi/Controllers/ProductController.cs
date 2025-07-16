using Application.Commands;
using Application.Interfaces;
using Application.Queries;
using Application.Queries.Handlers;
using Domain.Models.DTOs;
using Domain.Models.Requests;
using Domain.Models.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<List<ProductDto>> Get()
        {
            return await _mediator.Send(new GetAllProductQuery());
        }

            [HttpGet("{id}")]
        public async Task<ProductDto> Get(int id)
        {
            return await _mediator.Send(new GetProductByIdQuery { Id = id });
            }

        [HttpPost]
        public async Task<BaseResponse> Post(ProductRequest request)
        {
            return await _mediator.Send(new CreateProductCommand { productRequest = request });
            }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<BaseResponse> Put(int id, ProductRequest request)
        {
            return await _mediator.Send(new UpdateProductCommand { Id = id, productRequest = request });
            }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<BaseResponse> Delete(int id)
        {
            return await _mediator.Send(new DeleteProductCommand { Id = id });
            }
    }
}
