using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Home_Sewa.Helper
{
    public class ResponseModel
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public dynamic Result { get; set; }
    }

    public class Response
    {
        public static ResponseModel ApiResponse(bool status, string message, dynamic result)
        {
            return new ResponseModel
            {
                Status = status,
                Message = message,
                Result = result
            };
        }
    }
}
