using SporsalonuBYSS.Models;
using SporsalonuBYSS.Repisotory.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SporsalonuBYSS.Controllers
{
    public class AdminpUserController : Controller
    {
        SporSalonuYSDBEntities db = new SporSalonuYSDBEntities();
        UserConcrete userConcrete = new UserConcrete();
        // GET: AdminpUser
        public ActionResult GetUser()
        {
            return View(userConcrete.GetAll());
        }

        public ActionResult RemoveUser(int id)
        {
            SporSalonuYSDBEntities db = new SporSalonuYSDBEntities();
            User us = db.Users.FirstOrDefault(user => user.UserID == id);
            return View(us);
           
        }
        [HttpPost]
        public ActionResult RemoveUser(User us)
        {
            try
            {   
                userConcrete.Remove(us);
                return RedirectToAction("GetUser");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public ActionResult UpdateUser()
        {
            ViewBag.Role = db.Roles.ToList();
            return View(userConcrete.GetInclude());
        }

        [HttpPost]
        public ActionResult UpdateUser(User user)
        {
            try
            {
                userConcrete.Update(user);
                return RedirectToAction("UpdateUser");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(null, ex);
            }
            return View(user);
        }
    }
}