using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ViewModel
{
    public class ApiResponseModel
    {
        public string Version { get; set; }
        public HttpStatusCode ResponseCode { get; set; }
        public string Message { get; set; }
        public object Result { get; set; }
        public List<Validations> Error { get; set; }
    }

    public class Validations
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }

}
