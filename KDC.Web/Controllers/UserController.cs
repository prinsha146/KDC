using KDC.DL.DapperObjects;
using KDC.DL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KDC.Web.Controllers
{
    public class UserController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            if (Session["UserId"] != null)
            {
                base.OnActionExecuting(filterContext);

            }
            else
                filterContext.Result = new RedirectResult("~/Login/Index");
            //ilterContext.Result = new ViewResult { ViewName = "Index" };
        }
        UserRepo db = new UserRepo();

        public ActionResult Index()
        {
            var result = db.GetUserList();
            return View(result);
        }

        public ActionResult Create()
        {
            ViewBag.UserType = new SelectList(new List<SelectListItem>
            {
                new SelectListItem { Selected = false, Text = "Admin", Value = "Admin"},
                new SelectListItem { Selected = false, Text = "Lab", Value = "Lab"},
                new SelectListItem { Selected = false, Text = "Reception", Value = "Reception"}
            }, "Value", "Text", 1);

            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            SC_User user = new SC_User();
            try
            {
                user.FullName = collection["FullName"];
                user.Email = collection["Email"];
                user.UserName = collection["UserName"];
                user.Password = collection["Password"];
                user.UserType = collection["UserType"];
                user.EnteredDate = DateTime.Now;
                user.RegKey = collection["Regkey"];
                user.IsActive = Convert.ToBoolean(collection["IsActive"]);


                db.AddUser(user);
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Error = "Error Occured";
                return View(user);
            }
        }

        public ActionResult Details(int id)
        {
            var result = db.GetUserById(id);
            return View(result);
        }

        public ActionResult Edit(int id)
        {
            ViewBag.UserType = new SelectList(new List<SelectListItem>
            {
                new SelectListItem { Selected = false, Text = "Admin", Value = "Admin"},
                new SelectListItem { Selected = false, Text = "Lab", Value = "Lab"},
                new SelectListItem { Selected = false, Text = "Reception", Value = "Reception"}
            }, "Value", "Text", 1);

            var result = db.GetUserById(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            SC_User user = new SC_User();
            try
            {
                user.UserId = id;
                user.FullName = collection["FullName"];
                user.Email = collection["Email"];
                user.UserName = collection["UserName"];
                user.Password = collection["Password"];
                user.UserType = collection["UserType"];
                user.EnteredDate = DateTime.Now;
                user.RegKey = collection["Regkey"];
                user.IsActive = Convert.ToBoolean(collection["IsActive"]);

                db.EditUser(user);
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Error = "Error Occured";
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            db.RemoveUser(id);
            return RedirectToAction("Index");
        }

    }
}
