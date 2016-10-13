using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC.Objects;
using System.ComponentModel.DataAnnotations;

namespace MVC.Objects
{
    public class Timesheet : DBObject
    {
       
        public string ProjectName { get; set; }
        public int Hour { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }

        public Timesheet() : base("Timesheet")
        {
        
        }
    }
}