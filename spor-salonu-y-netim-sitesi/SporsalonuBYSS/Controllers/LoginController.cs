using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SporsalonuBYSS.Models;
using SporsalonuBYSS.Repisotory;
using SporsalonuBYSS.Repisotory.Concrete;

namespace SporsalonuBYSS.Controllers
{
    public class LoginController : Controller
    {

        SporSalonuYSDBEntities db = new SporSalonuYSDBEntities();
        [HttpGet]
        public ActionResult LogonPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogonPage(string username, string password)
        {
            //Sadece kullanıcıları kontrol eden giriş metodu
            var checkuser = db.Users.FirstOrDefault(u => u.Username == username &&
                 u.Password == password && u.RoleID == 1);

            //Sadece yöneticileri kontrol eden giriş metodu
            var checkadmin = db.Users.FirstOrDefault(u => u.Username == username &&
         u.Password == password && u.RoleID == 2);

            if (checkuser != null)
            {
                var checkmember = db.Members.FirstOrDefault(m => m.UserID == checkuser.UserID);
                Session.Add("Username", checkuser.Username);
                Session.Add("EMail", checkuser.EMail);
                Session.Add("Password", checkuser.Password);
                Session.Add("Membername", checkmember.Firstname);
                Session.Add("Memberid", checkmember.MembersID);
                Session.Add("UserID", checkuser.UserID);
                Session.Add("Firstname", checkmember.Firstname);
                Session.Add("LastName", checkmember.LastName);
                Session.Add("Phone", checkmember.Phone);

                return RedirectToAction("UserIndex", "Home");
            }
            else if (checkadmin != null)
            {
                Session.Add("Managername", checkadmin.Username);
                Session.Add("Managerid", checkadmin.UserID);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                Session.Add("Hatamesaji", "Hatalı giriş");
                return View();
            }
        }
    }
}