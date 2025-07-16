using Domain.Models.Requests;
using Domain.Models.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class CreateProductCommand : IRequest<BaseResponse>
    {
        public ProductRequest   productRequest { get; set; }
    }
}
