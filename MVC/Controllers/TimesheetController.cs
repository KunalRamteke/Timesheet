using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Objects;
using MVC.Providers;

namespace MVC.Controllers
{
    [HandleError]
    public class TimesheetController :  Controller
    {
        public ActionResult Login()
        { 
            return View();
        }

        [HttpPost]
        [HandleError(View = "Error")]
        public ActionResult Login(User objUser )
        {
            Error error = new Error();
            
            try
            {
                if (Session["UserObject"] == null)
                {
                    error = Engine.UserAuthentication(objUser);
                    if (error.IsSuccess == true)
                    {
                        Session["UserObject"] = (User)error.Data;
                        return RedirectToAction("LoadTimesheet");
                    }
                    else
                    {
                        TempData["Error"] = error;
                        return RedirectToAction("Login");
                        
                    }
               }
                else
                    return RedirectToAction("LoadTimesheet");
            }
            catch (Exception Ex)
            {
                error.ErrorMessage = Ex.Message;
                TempData["Error"] = error;
                return RedirectToAction("Login", error);
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User objUser)
        {
            Error error = Engine.RegisterAccount(objUser);
            if (error.IsSuccess == true)
            {
                ViewBag.Message = "Registration Successfull. Please Login!";
                return RedirectToAction("Login");
            }
            else
            {
                TempData["Error"] = error;
                return View();
            }
        }
        
        public ActionResult LoadTimesheet()
        {
            
            Error error = new Error();
            try
            {                
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
                Response.Cache.SetNoStore();
                if (Session["UserObject"] == null)
                {
                    error.ErrorMessage = TimesheetResources.ResourceManager.GetString("SessionExpire");
                    return RedirectToAction("Login");
                }
                else
                    return View();
            }
            catch(Exception Ex)
            {
                error.ErrorMessage = Ex.Message;
                TempData["Error"] = error;
                return RedirectToAction("Login");
            }
        }
        
        public ActionResult About()
        {
            ViewBag.Message = "Welcome!!!";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public ActionResult Logout()
        {
            
            Session.Abandon();           
            ViewBag.Message = "Your Login Page.";
            return RedirectToAction("Login");
        }

        public ActionResult Login2()
        {
           return RedirectToAction("Error");
        }
    }
}