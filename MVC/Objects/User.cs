using MVC.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Objects
{
    public class User : DBObject
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User():base("User")
        {
        
        }
    }
}