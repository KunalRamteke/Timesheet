using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MVC.Objects;
using MVC.Providers;
using MVC.Services;
using System.Web.Http.Filters;

namespace MVC.Controllers
{
    
    public class SystemController : ApiController
    {
        List<Timesheet> lstTimesheet;
        
        [HttpGet]
        public IEnumerable<Timesheet> Timesheet(Guid id)
        {
            Error error = null;
            
                lstTimesheet = new List<Timesheet>();
                User objUser = new User();
                objUser.Id = id;
                error = Identity.LoadTimesheet(objUser);
                if (error.Data != null)
                {
                    lstTimesheet.AddRange(error.Data as List<Timesheet>);
                    return lstTimesheet;
                }
                else
                    return lstTimesheet;            
        }
        
        [HttpPost]
        [Authorize(Users = "sandip,Jini")]
        public string CreateTimesheet(Timesheet objTimesheet)
        {
               // int u = Convert.ToInt32("");// Error line
                Error error = Engine.NewTimesheet(objTimesheet);
                if (error.IsSuccess == true)
                    return "Data succesfully inserted";
                else
                    return "error occured";
        }

        [HttpPut]
        public void Edit(Timesheet objTimesheet)
        {
            Error error = Identity.EditTimesheet(objTimesheet);
        }

        [HttpDelete]
        public void Delete(Guid id)
        {
            Timesheet objTimesheet = new Timesheet();
            objTimesheet.Id = id;
            Error error = Identity.DeleteTimesheet(objTimesheet);
        }
    }
}
