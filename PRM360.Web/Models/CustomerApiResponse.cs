using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PRM360.Web.Models
{
    public class CustomerApiResponseMessage
    {
        public HttpStatusCode Status { get; set; }
        public bool Success { get; set; }
        public string Result { get; set; }
        public string Message { get; set; }
    }
}
