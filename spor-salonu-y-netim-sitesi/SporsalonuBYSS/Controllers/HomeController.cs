using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SporsalonuBYSS.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UserIndex()
        {
            return View();
        }
        public ActionResult GetContact()
        {
            return View();
        }
    }
}