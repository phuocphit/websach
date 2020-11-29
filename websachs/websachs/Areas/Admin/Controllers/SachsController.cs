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
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            var sachs = db.Sachs.Include(s => s.LoaiSach).Include(s => s.NhaXuatBan);
            return View(sachs.ToList());
        }

        // GET: Admin/Sachs/Details/5
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
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            ViewBag.MaLoaiSach = new SelectList(db.LoaiSachs, "MaLoaiSach", "TenLoaiSach");
            ViewBag.MaNXB = new SelectList(db.NhaXuatBans, "MaNXB", "TenNXB");
            return View();
        }

        // POST: Admin/Sachs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSach,TenSach,MaLoaiSach,TacGia,MaNXB,GiaBan,SoLuongTon,NamXuatBan")] Sach sach, HttpPostedFileBase image)
        {
            if (image != null && image.ContentLength > 0)
            {
                sach.Image = new byte[image.ContentLength]; // image stored in binary formate
                image.InputStream.Read(sach.Image, 0, image.ContentLength);
                string fileName = System.IO.Path.GetFileName(image.FileName);
                string urlImage = Server.MapPath("/Image/" + fileName);
                image.SaveAs(urlImage);

                sach.UrlImage = "/Image/" + fileName;
            }

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
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
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
        public ActionResult Edit([Bind(Include = "MaSach,TenSach,MaLoaiSach,TacGia,MaNXB,GiaBan,SoLuongTon,NamXuatBan")] Sach sach, HttpPostedFileBase editImage)
        {
            if (ModelState.IsValid)
            {
                Sach modifySach = db.Sachs.Find(sach.MaSach);
                if (modifySach != null)
                {
                    if (editImage != null && editImage.ContentLength > 0)
                    {
                        modifySach.Image = new byte[editImage.ContentLength]; // image stored in binary formate
                        editImage.InputStream.Read(modifySach.Image, 0, editImage.ContentLength);
                        string fileName = System.IO.Path.GetFileName(editImage.FileName);
                        string urlImage = Server.MapPath("~/Image/" + fileName);
                        editImage.SaveAs(urlImage);

                        modifySach.UrlImage = "Image/" + fileName;
                    }
                }
                db.Entry(modifySach).State = EntityState.Modified;
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
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
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
