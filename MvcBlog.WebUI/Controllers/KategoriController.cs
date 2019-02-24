using MvcBlog.Bussiness.DbManager;
using MvcBlog.Entities.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlog.WebUI.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        public ActionResult KategoriListesi()
        {
            var kategoriler = DBReadWrite<Kategori>.GetAll();
            return View(kategoriler);
        }

        [HttpGet]
        public ActionResult Create(int? id = null)
        {
            if (id == null)
            {
                return View();
            }
            else
            {
                var kategori = DBReadWrite<Kategori>.GetEntity(x => x.KategoriID == id);
                return View(kategori);
            }

        }

        [HttpPost]
        public ActionResult Create(Kategori kategori)
        {
            if (kategori.KategoriID == 0)
            {
                DBReadWrite<Kategori>.Add(kategori);
            }
            else
            {
                var kat=DBReadWrite<Kategori>.GetEntity(x => x.KategoriID == kategori.KategoriID);
                kat = kategori;


                DBReadWrite<Kategori>.Update(kat);
            }

            return RedirectToAction("KategoriListesi");
        }



    }
}