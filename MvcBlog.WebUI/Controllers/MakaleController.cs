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
    //[Authorize]
    public class MakaleController : Controller
    {
        private BlogContext db = new BlogContext();

        // GET: Makale
       // [AllowAnonymous]//herkese açılır
       [Authorize(Roles ="Admin,User")]
        public ActionResult Index()
        {
            var makaleler = db.Makaleler.Include(m => m.Kategori).Include(m => m.Yazar);
            return View(makaleler.ToList());
        }

        // GET: Makale/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Makale makale = db.Makaleler.Find(id);
            if (makale == null)
            {
                return HttpNotFound();
            }
            return View(makale);
        }

        // GET: Makale/Create
       [Authorize(Roles ="Admin")]
        public ActionResult Create()
        {
            ViewBag.KategoriID = new SelectList(db.Kategoriler, "KategoriID", "KategoriAdi");
            ViewBag.YazarID = new SelectList(db.Yazarlar, "YazarID", "Ad");
            return View();
        }

        // POST: Makale/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MakaleID,Baslik,Icerik,YayinTarihi,KategoriID,YazarID")] Makale makale)
        {
            if (ModelState.IsValid)
            {
                db.Makaleler.Add(makale);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KategoriID = new SelectList(db.Kategoriler, "KategoriID", "KategoriAdi", makale.KategoriID);
            ViewBag.YazarID = new SelectList(db.Yazarlar, "YazarID", "Ad", makale.YazarID);
            return View(makale);
        }

        // GET: Makale/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Makale makale = db.Makaleler.Find(id);
            if (makale == null)
            {
                return HttpNotFound();
            }
            ViewBag.KategoriID = new SelectList(db.Kategoriler, "KategoriID", "KategoriAdi", makale.KategoriID);
            ViewBag.YazarID = new SelectList(db.Yazarlar, "YazarID", "Ad", makale.YazarID);
            return View(makale);
        }

        // POST: Makale/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MakaleID,Baslik,Icerik,YayinTarihi,KategoriID,YazarID")] Makale makale)
        {
            if (ModelState.IsValid)
            {
                db.Entry(makale).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KategoriID = new SelectList(db.Kategoriler, "KategoriID", "KategoriAdi", makale.KategoriID);
            ViewBag.YazarID = new SelectList(db.Yazarlar, "YazarID", "Ad", makale.YazarID);
            return View(makale);
        }

        // GET: Makale/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Makale makale = db.Makaleler.Find(id);
            if (makale == null)
            {
                return HttpNotFound();
            }
            return View(makale);
        }

        // POST: Makale/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Makale makale = db.Makaleler.Find(id);
            db.Makaleler.Remove(makale);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
