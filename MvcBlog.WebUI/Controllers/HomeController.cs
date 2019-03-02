using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcBlog.DataAccess.Concrete.EntitiyFramework;
using MvcBlog.Entities.Concrete.Entities;

namespace MvcBlog.WebUI.Controllers
{
    public class HomeController : Controller
    {
        BlogContext db = new BlogContext();
        public ActionResult Index()
        {

            var makaleler = db.Makaleler.Include(m => m.Kategori).Include(m => m.Yazar);
            return View(makaleler.ToList());
        }
        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpNotFoundResult();
            }
            else
            {
                var makale = db.Makaleler.Include(m => m.Kategori).Include(m => m.Yazar);
                return View(makale.FirstOrDefault(x => x.MakaleID == id));
            }

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact";

            return View();
        }
    }
}