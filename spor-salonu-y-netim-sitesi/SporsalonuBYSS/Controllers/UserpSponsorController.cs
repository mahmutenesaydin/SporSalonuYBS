using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SporsalonuBYSS.Models;
using SporsalonuBYSS.Repisotory.Concrete;

namespace SporsalonuBYSS.Controllers
{
    public class UserpSponsorController : Controller
    {
        SponsorConcrete spconcrete = new SponsorConcrete();
        SporSalonuYSDBEntities db = new SporSalonuYSDBEntities();
        
        // GET: UserpSponsor
        public ActionResult ListSponsor()
        {
            return View(spconcrete.GetIncludeList());
        }
    }
}