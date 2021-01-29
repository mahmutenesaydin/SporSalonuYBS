using SporsalonuBYSS.Models;
using SporsalonuBYSS.Repisotory.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SporsalonuBYSS.Controllers
{
    public class MemberController : Controller
    {
        SporSalonuYSDBEntities db = new SporSalonuYSDBEntities();
        UserConcrete userConcrete = new UserConcrete();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("LogonPage", "Login");
        }

        [HttpGet]
        public ActionResult UpdateUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var username = User.Identity.Name;
                var model = db.Users.FirstOrDefault(x => x.Username == username);
                if (model != null)
                {
                    return View(model);
                }
                else
                {
                    return View(new User());
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult UpdateUser(User u, Member m)
        {
            u.RoleID = 1;
            u.RoleID = m.UserID;
            db.Entry(u).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("LogonPage", "Login");
        }
    }
}