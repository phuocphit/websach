using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using websachs.Models;

namespace websachs.Areas.Admin.Controllers
{
    public class LoaiSachsController : Controller
    {
        private DBcontext db = new DBcontext();

        // GET: Admin/LoaiSachs
        public ActionResult Index()
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Login", "Home");
            }

            return View(db.LoaiSachs.ToList());
        }

        // GET: Admin/LoaiSachs/Details/5
        public ActionResult Details(string id)
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Login", "Home");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiSach loaiSach = db.LoaiSachs.Find(id);
            if (loaiSach == null)
            {
                return HttpNotFound();
            }
            return View(loaiSach);
        }

        // GET: Admin/LoaiSachs/Create
        public ActionResult Create()
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Login", "Home");
            }

            return View();
        }

        // POST: Admin/LoaiSachs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLoaiSach,TenLoaiSach")] LoaiSach loaiSach)
        {
            if (ModelState.IsValid)
            {
                db.LoaiSachs.Add(loaiSach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loaiSach);
        }

        // GET: Admin/LoaiSachs/Edit/5
        public ActionResult Edit(string id)
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Login", "Home");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiSach loaiSach = db.LoaiSachs.Find(id);
            if (loaiSach == null)
            {
                return HttpNotFound();
            }
            return View(loaiSach);
        }

        // POST: Admin/LoaiSachs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLoaiSach,TenLoaiSach")] LoaiSach loaiSach)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaiSach).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loaiSach);
        }

        // GET: Admin/LoaiSachs/Delete/5
        public ActionResult Delete(string id)
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Login", "Home");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiSach loaiSach = db.LoaiSachs.Find(id);
            if (loaiSach == null)
            {
                return HttpNotFound();
            }
            return View(loaiSach);
        }

        // POST: Admin/LoaiSachs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            LoaiSach loaiSach = db.LoaiSachs.Find(id);
            db.LoaiSachs.Remove(loaiSach);
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
