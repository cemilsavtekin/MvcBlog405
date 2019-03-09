using MvcBlog.Bussiness.DbManager;
using MvcBlog.Entities.Concrete.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcBlog.WebUI.Controllers
{
    public class SecurityController : Controller
    {
        // GET: Security
        public ActionResult Login()
        {
            //HttpContext.User.IsInRole("User");
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            var userInDb = DBReadWrite<User>.GetEntity(x => x.Username == user.Username && x.Password == user.Password);

            if (userInDb !=null)
            {
                FormsAuthentication.SetAuthCookie(userInDb.Username,false);
                return RedirectToAction("Index", "Makale");
            }
            else
            {
                ViewBag.ErrorMessage = "geçersiz kullanıcı adi";
                ViewData["ErrorMessage"] = "geçersiz kullanıcı adi";
                TempData["ErrorMessage"] = "geçersiz kullanıcı adi";

                return View();
            }
            
        }

       
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index","Home");
        }
    }
}