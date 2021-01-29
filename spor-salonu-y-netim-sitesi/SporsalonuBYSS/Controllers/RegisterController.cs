using SporsalonuBYSS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SporsalonuBYSS.Controllers
{
    public class RegisterController : Controller
    {
        SporSalonuYSDBEntities db = new SporSalonuYSDBEntities();

        [HttpGet]
        public ActionResult RegisterPage()
        {
            return View();
        }


        [HttpPost]
        public ActionResult RegisterPage(User u, Member m)
        {
            //User tablosuna  ekleme
            u.RoleID = 1; // otomatik olarak her kayıt olan "kullanıcı"dır
            db.Users.Add(u);
            db.SaveChanges();
            Session["RoleID"] = u.RoleID;
            Session["Username"] = u.Username;
            Session["Password"] = u.Password;
            Session["EMail"] = u.EMail;


            //User tablosuna  ekleme
            m.UserID = u.UserID;
            db.Members.Add(m);
            db.SaveChanges();
            Session["Firstname"] = m.Firstname;
            Session["Lastname"] = m.LastName;
            Session["Phone"] = m.Phone;

            return RedirectToAction("LogonPage", "Login");
        }
    }
}