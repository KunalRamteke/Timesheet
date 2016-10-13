using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC.Objects;
using MVC.Dao;
using Newtonsoft.Json;

namespace MVC.Services
{
    public class Identity
    {

        public static Error UserAuthentication(User objUser)
        {
            Error error = Data.LoadUser(objUser);
            try
            {
                if (error.IsSuccess == true)
                {
                    error.IsSuccess = false;
                    List<object> lstUser = error.Data as List<object>;
                    foreach (object obj in lstUser)
                    {
                        User objCurrent = JsonConvert.DeserializeObject<User>(JsonConvert.SerializeObject(obj));
                        if (objUser.Email == objCurrent.Email && objUser.Password == objCurrent.Password)
                        {
                            error.Data = objCurrent;
                            error.IsSuccess = true;
                            break;
                        }
                    }
                    if (error.IsSuccess == false)
                    {
                        error.Data = null;
                        error.ErrorMessage = TimesheetResources.ResourceManager.GetString("UserNotFound");
                    }
                }
            }
            catch(Exception Ex)
            {
                error.IsSuccess = false;
                error.ErrorMessage = Ex.Message;
                error.Data = Ex;
            }
            return error;
        }

        public static Error NewTimesheet(Timesheet objTimesheet)
        {
            return Data.Save(objTimesheet);
        }

        public static Error RegisterAccount(User objUser)
        {
            Error error = Data.LoadUser(objUser); 
            try
            {
                if (error.IsSuccess == true)
                {
                    List<object> lstUser = error.Data as List<object>;
                    if (lstUser == null)
                    {
                        return Data.Save(objUser);
                    }
                    else
                    {
                        foreach (object obj in lstUser)
                        {
                            User objCurrent = JsonConvert.DeserializeObject<User>(JsonConvert.SerializeObject(obj));
                            if (objUser.Email == objCurrent.Email)
                            {
                                error.IsSuccess = false;
                                error.ErrorMessage = TimesheetResources.ResourceManager.GetString("DuplicateEmail");
                                error.Data = null;
                                return error;
                            }
                        }
                        return Data.Save(objUser);
                    }
                }
            }
            catch(Exception Ex)
            {
                error.IsSuccess = false;
                error.ErrorMessage = Ex.Message;
                error.Data = Ex;
            }
            return error;
        }

        public static Error LoadTimesheet(User objUser)
        {           
            return  Data.LoadTimesheet(objUser);
        }

        public static Error EditTimesheet(Timesheet objTimesheet)
        {
            return Data.EditTimesheet(objTimesheet);
        }

        public static Error DeleteTimesheet(Timesheet objTimesheet)
        {
            return Data.DeleteTimesheet(objTimesheet);
        }
    }
}