using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Objects
{
    public class Error
    {
        public Boolean IsSuccess { get; set; }
        public object Data { get; set; }
        public string ErrorMessage { get; set; }
       
    }

}