using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Configuration;
using System.Resources;
using Newtonsoft.Json;
using MVC.Objects;

namespace MVC
{
    public class Storage
    {
        
        public static Error Load(string fileName)
        {
            Error error = new Error();
            try
            {                
                string filePath = ConfigurationManager.AppSettings[fileName];
                filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath);
                  if (!File.Exists(filePath))
                    {
                        error.IsSuccess = false;
                        error.ErrorMessage = TimesheetResources.ResourceManager.GetString("LoadError");
                        return error;
                    }
                    else
                    {
                        string str = File.ReadAllText(filePath);
                        error.Data = JsonConvert.DeserializeObject<List<object>>(str);
                        error.IsSuccess = true;
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

        public static Error Save(string fileName, string data)
        {
            Error error = new Error();
            try
            {
                string filePath = ConfigurationManager.AppSettings[fileName];
                filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath);
                File.WriteAllText(filePath, data);
                error.IsSuccess = true;                
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