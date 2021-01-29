using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SporsalonuBYSS.Models;
using SporsalonuBYSS.Repisotory.Concrete;

namespace SporsalonuBYSS.Controllers
{
    public class AdminipSponsorController : Controller
    {
        SporSalonuYSDBEntities db = new SporSalonuYSDBEntities();
        SponsorConcrete spconcrete = new SponsorConcrete();
        // GET: AdminipSponsor
        public ActionResult GetSponsor()
        {
            return View(spconcrete.GetAll());
        }
        public ActionResult AddSponsor()
        {
            return View(spconcrete.GetAll());
        }
        [HttpPost]
        public ActionResult AddSponsor(Sponsor s)
        {
            spconcrete.Add(s);
            return RedirectToAction("AddSponsor");
        }
        public ActionResult RemoveSponsor(int id)
        {
            return View(spconcrete.GetID(id));
        }
        [HttpPost]
        public ActionResult RemoveSponsor(Sponsor sp)
        {
            spconcrete.Remove(sp);
            return RedirectToAction("GetSponsor");
        }
        public ActionResult UpdateSponsor()
        {
            return View(spconcrete.GetAll());
        }
        [HttpPost]
        public ActionResult UpdateSponsor(Sponsor s)
        {
            spconcrete.Update(s);
            return RedirectToAction("UpdateSponsor");
        }

    }
}