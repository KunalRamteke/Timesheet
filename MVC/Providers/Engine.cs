using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC.Dao;
using MVC.Objects;
using MVC.Services;

namespace MVC.Providers
{
    public class Engine
    {
        public static Error UserAuthentication(User objUser)
        {
            return Identity.UserAuthentication(objUser);
        }
        
        public static Error RegisterAccount(User objUser)
        {
            return Identity.RegisterAccount(objUser);
        }
        
        public static Error LoadTimesheet(User objUser)
        {
            return Identity.LoadTimesheet(objUser);
        }

        public static Error NewTimesheet(Timesheet objTimesheet)
        {
            return Identity.NewTimesheet(objTimesheet);
        }

        public static Error EditTimesheet(Timesheet objTimesheet)
        {
            return Identity.EditTimesheet(objTimesheet);
        }

        public static Error DeleteTimesheet(Timesheet objTimesheet)
        {
            return Identity.DeleteTimesheet(objTimesheet);
        }
    }
}