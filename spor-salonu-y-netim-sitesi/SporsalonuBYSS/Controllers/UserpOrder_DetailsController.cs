using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SporsalonuBYSS.Models;
using SporsalonuBYSS.Repisotory.Concrete;

namespace SporsalonuBYSS.Controllers
{
    public class UserpOrder_DetailsController : Controller
    {
        OrderDetailConcrete odConcrete = new OrderDetailConcrete();
        SporSalonuYSDBEntities db = new SporSalonuYSDBEntities();
        // GET: UserpOrder_Details
        public ActionResult OrderDetailsIndex()
        {
            int userid = Convert.ToInt32(HttpContext.Session["Memberid"]);
            return View(odConcrete.GetInclude(userid));
        }
    }
}