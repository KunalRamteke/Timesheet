using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC.Objects;
using Newtonsoft.Json;

namespace MVC.Dao
{
    public class Data
    {
        
        public static Error Save(DBObject obj)
        {
            obj.Id = Guid.NewGuid();
            Error error = Storage.Load(obj.ObjType);;
            try
            {
                if (error.IsSuccess == true)
                {
                    List<object> lstObjects = new List<object>();
                    if (error.Data == null)
                    {
                        lstObjects.Add(obj);
                        error = Storage.Save(obj.ObjType, JsonConvert.SerializeObject(lstObjects));
                        error.IsSuccess = true;
                    }
                    else
                    {
                        lstObjects = error.Data as List<object>;
                        lstObjects.Add(obj);
                        error = Storage.Save(obj.ObjType, JsonConvert.SerializeObject(lstObjects));
                        error.IsSuccess = true;
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

        public static Error LoadUser(DBObject objUser)
        {
            return Storage.Load(objUser.ObjType);
        }

        public static Error LoadTimesheet(DBObject objUser)
        {
            Error error = Storage.Load("Timesheet");
            try
            {
                if (error.IsSuccess == true)
                {
                    List<object> lstTimesheet = error.Data as List<object>;
                    List<Timesheet> lstUserTimesheet = new List<Timesheet>();
                    if (error.Data == null)
                    {
                        error.ErrorMessage = TimesheetResources.ResourceManager.GetString("NullRecord");
                        error.IsSuccess = false;
                    }
                    else
                    {
                        foreach (object obj in lstTimesheet)
                        {
                            Timesheet objCurrent = JsonConvert.DeserializeObject<Timesheet>(JsonConvert.SerializeObject(obj));
                            if (objUser.Id == objCurrent.UserId)
                                lstUserTimesheet.Add(objCurrent);
                        }
                        if (!(lstUserTimesheet.Count == 0))
                        {
                            error.Data = lstUserTimesheet;
                            error.IsSuccess = true;
                        }
                        else
                        {
                            error.Data = null;
                            error.IsSuccess = false;
                        }
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

        public static Error EditTimesheet(DBObject objTimesheet)
        {
            Error error = Storage.Load(objTimesheet.ObjType);
            try
            {
                if (error.IsSuccess == true)
                {
                    List<object> lstTimesheet = error.Data as List<object>;
                    foreach (object obj in lstTimesheet)
                    {
                        Timesheet objCurrent = JsonConvert.DeserializeObject<Timesheet>(JsonConvert.SerializeObject(obj));
                        if (objTimesheet.Id == objCurrent.Id)
                        {
                            lstTimesheet.Remove(obj);
                            lstTimesheet.Add(objTimesheet);
                            error = Storage.Save(objTimesheet.ObjType, JsonConvert.SerializeObject(lstTimesheet));
                            break;
                        }
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

        public static Error DeleteTimesheet(DBObject objTimesheet)
        {
            Error error = Storage.Load(objTimesheet.ObjType);
            try
            {
                if (error.IsSuccess == true)
                {
                    List<object> lstTimesheet = error.Data as List<object>;
                    foreach (object obj in lstTimesheet)
                    {
                        Timesheet objCurrent = JsonConvert.DeserializeObject<Timesheet>(JsonConvert.SerializeObject(obj));
                        if (objTimesheet.Id == objCurrent.Id)
                        {
                            lstTimesheet.Remove(obj);
                            error = Storage.Save(objTimesheet.ObjType, JsonConvert.SerializeObject(lstTimesheet));
                            error.IsSuccess = true;
                            break;
                        }
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
    }
}