using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApplication.DTO
{
    public class ResponseModel<T>
    {
        public T Data { get; set; }
        public Boolean Success { get; set; } = false;
        public string ErrorMessage { get; set; }
    }
}
