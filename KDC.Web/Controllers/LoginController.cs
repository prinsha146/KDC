using KDC.DL.DapperObjects;
using KDC.DL.Models;
using KDC.DL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace KDC.Web.Controllers
{
    public class LoginController : Controller
    {
        private LoginRepo db = new LoginRepo();
        // GET: Login
        public ActionResult Index(string returnUrl = "")
        {
            ViewBag.SuccessMessage = "";
            ViewBag.ReturnUrl = returnUrl;
            ViewBag.Message = "";
            return View();
        }

        [HttpPost]
        public ActionResult Index(string Email, string Password, string returnUrl)
        {
            ViewBag.Message = "";
            ViewBag.SuccessMessage = "";
            var user = db.CheckLogin(Email, Password, returnUrl);
            if (user == null)
            {
                ViewBag.Message = "Username or Password is incorrect.";
                return View();
            }
            else
            {
                Session["UserId"] = user.UserId;
                Session["FullName"] = user.FullName;
                Session["UserType"] = user.UserType;

                if (Convert.ToString(Session["UserType"]) == "Admin" || Convert.ToString(Session["UserType"]) == "Reception")
                {
                    return RedirectToAction("Index", "Candidate");
                }
                if (Convert.ToString(Session["UserType"]) == "Lab")
                {
                    return RedirectToAction("Index", "LabEntry");
                }
                return RedirectToAction("Index", "Dashboard");
            }
        }

        public ActionResult LogOut()
        {
            Session.RemoveAll();
            ViewBag.Message = "";
            ViewBag.SuccessMessage = "You have logged out successfully";
            return RedirectToAction("Index", "Login");
        }

    }
}
