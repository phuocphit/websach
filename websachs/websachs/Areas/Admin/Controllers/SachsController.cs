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
    public class SachsController : Controller
    {
        private DBcontext db = new DBcontext();

        // GET: Admin/Sachs
        public ActionResult Index()
        {
            var sachs = db.Sachs.Include(s => s.LoaiSach).Include(s => s.NhaXuatBan);
            return View(sachs.ToList());
        }

        // GET: Admin/Sachs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sach sach = db.Sachs.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }
            return View(sach);
        }

        // GET: Admin/Sachs/Create
        public ActionResult Create()
        {
            ViewBag.MaLoaiSach = new SelectList(db.LoaiSachs, "MaLoaiSach", "TenLoaiSach");
            ViewBag.MaNXB = new SelectList(db.NhaXuatBans, "MaNXB", "TenNXB");
            return View();
        }

        // POST: Admin/Sachs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSach,TenSach,MaLoaiSach,TacGia,MaNXB,GiaBan,SoLuongTon,SoTrang,images,NamXuatBan,NoiDung")] Sach sach)
        {
            if (ModelState.IsValid)
            {
                db.Sachs.Add(sach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLoaiSach = new SelectList(db.LoaiSachs, "MaLoaiSach", "TenLoaiSach", sach.MaLoaiSach);
            ViewBag.MaNXB = new SelectList(db.NhaXuatBans, "MaNXB", "TenNXB", sach.MaNXB);
            return View(sach);
        }

        // GET: Admin/Sachs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sach sach = db.Sachs.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLoaiSach = new SelectList(db.LoaiSachs, "MaLoaiSach", "TenLoaiSach", sach.MaLoaiSach);
            ViewBag.MaNXB = new SelectList(db.NhaXuatBans, "MaNXB", "TenNXB", sach.MaNXB);
            return View(sach);
        }

        // POST: Admin/Sachs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSach,TenSach,MaLoaiSach,TacGia,MaNXB,GiaBan,SoLuongTon,SoTrang,images,NamXuatBan,NoiDung")] Sach sach)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sach).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoaiSach = new SelectList(db.LoaiSachs, "MaLoaiSach", "TenLoaiSach", sach.MaLoaiSach);
            ViewBag.MaNXB = new SelectList(db.NhaXuatBans, "MaNXB", "TenNXB", sach.MaNXB);
            return View(sach);
        }

        // GET: Admin/Sachs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sach sach = db.Sachs.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }
            return View(sach);
        }

        // POST: Admin/Sachs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Sach sach = db.Sachs.Find(id);
            db.Sachs.Remove(sach);
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
