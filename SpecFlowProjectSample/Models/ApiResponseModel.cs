using System;
using System.Collections.Generic;
using System.Text;

namespace SpecflowAssesment.Models
{
   public class ApiResponseModel
    {
        public int StatusCode { get; set; } 
        public AccountModel Data { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
    }
}
