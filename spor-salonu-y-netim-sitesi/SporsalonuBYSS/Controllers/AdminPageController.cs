using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SporsalonuBYSS.Controllers
{
    public class AdminPageController : Controller
    {
        // GET: AdminPage
        public ActionResult AdminIndex()
        {
            return View();
        }
    }
}