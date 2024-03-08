using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class ResponseMessage
    {
        public string? Message { get; set; }
        public bool Result { get; set; }
        public int StatusCode { get; set; }
        public RegistrationInfo RegistrationInfo { get; set; }

        public ResponseMessage(string message, bool result, int statuscode, RegistrationInfo info)
        {
            Message = message;
            Result = result;
            StatusCode = statuscode;
            RegistrationInfo = info;
        }
    }

    public class RegistrationInfo
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }


    public class IdResponse
    {
        public string? Message { get; set; }
        public bool Result { get; set; }
        public int StatusCode { get; set; }
        public int Id {  get; set; }

        public IdResponse(string message,bool result,int statuscode,int id)
        {
            Message = message;
            Result = result;
            StatusCode = statuscode;
            Id = id;
        }
    }

    public class Response
    {
        public string? Message { get; set; }
        public bool Result { get; set; }
        public int StatusCode { get; set; }
    

        public Response(string message, bool result, int statuscode) 
        {
            Message = message;
            Result = result;
            StatusCode = statuscode;
         
        }
    }

    public class CommonResponse
    {
        public string? Message { get; set; }
        public int StatusCode { get; set; }

        public CommonResponse(string message,int statuscode)
        {
            Message=message;
            StatusCode = statuscode;
        }
    }
}
