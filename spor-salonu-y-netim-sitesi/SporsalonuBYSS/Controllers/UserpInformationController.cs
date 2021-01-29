using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SporsalonuBYSS.Models;
using SporsalonuBYSS.Repisotory.Concrete;

namespace SporsalonuBYSS.Controllers
{
    public class UserpInformationController : Controller
    {
        CoachConcrete trainer_concrete = new CoachConcrete();   
        // GET: UserpInformation
        public ActionResult GetInformation()
        {
            return View(trainer_concrete.GetInclude());
        }
    }
}