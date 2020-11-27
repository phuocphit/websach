using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using System.Text;
using websachs.Models;

namespace websachs.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            DBcontext db = new DBcontext();
            if (ModelState.IsValid)
            {
                var check = db.Users.FirstOrDefault(s => s.Email == user.Email);
                if (check == null)
                {
                    user.PassWord = GetMD5(user.PassWord);
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.Users.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.error = "Email already exists";
                    return View();
                }


            }
            return View();


        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            DBcontext db = new DBcontext();
            if (ModelState.IsValid)
            {


                var f_password = GetMD5(password);
                var data = db.Users.Where(s => s.Email.Equals(email) && s.PassWord.Equals(f_password)).FirstOrDefault();
                if (data != null)
                {
                    //add session
                    Session["UserName"] = data.UserName;
                    Session["Email"] = data.Email;
                    var checkAdmin = data.RoleName;
                    if(checkAdmin == "Admin")
                    {
                        return RedirectToAction("Index","Home",new { Area = "Admin"});
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                    
                }
                else
                {
                    ViewBag.error = "Đăng nhập thất bại";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }


        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }




    }
}