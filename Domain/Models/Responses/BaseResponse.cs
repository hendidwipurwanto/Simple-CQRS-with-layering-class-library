using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Responses
{
    public class BaseResponse
    {
        public BaseResponse()
        {
            StatusCode = 200; // Default to OK
            Message = "Success"; // Default message
        }
        public int StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
