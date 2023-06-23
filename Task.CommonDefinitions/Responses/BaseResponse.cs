using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Task.CommonDefinitions.Responses
{
    public class BaseResponse<T>
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public int TotalCount { get; set; }

        public T EntityDTO { get; set; }
        public List<T> EntityDTOs { get; set; }
    }
}
