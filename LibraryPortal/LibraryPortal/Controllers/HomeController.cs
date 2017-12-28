using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommonLayer;
using BussinessLayer;
using CommonLayer.ViewModel;
using System.Web.Security;

namespace LibraryPortal.Controllers
{
    public class HomeController : Controller
    {
        UserAuthenticate ua = new UserAuthenticate();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
      
        public ActionResult LogIn()
            {
            return View();
        }


        [HttpPost]
        public ActionResult LogIn(Login model)
            {
            Login loginObj = ua.Authenticate(model);

            if (loginObj != null)
            {
                //FormsAuthentication.SetAuthCookie(model.Username, false);

                string Role = loginObj.Roles;

                var authTicket = new FormsAuthenticationTicket(1, model.Username, DateTime.Now, DateTime.Now.AddHours(2), false, Role);

                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);

                var httpCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                Response.Cookies.Add(httpCookie);
                return Json(new { redirecturl = "Home/UserHome" }, JsonRequestBehavior.AllowGet);

                //return RedirectToAction("UserHome");
                //return View("UserHome");
            }
            else
            {
                ModelState.AddModelError("","");
                return View("LogIn");
            }

                
            ViewBag.msg = "Invalid credentials";
            return View("LogIn");
            
        }

        [Authorize]
        public ActionResult UserHome()
        {
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}