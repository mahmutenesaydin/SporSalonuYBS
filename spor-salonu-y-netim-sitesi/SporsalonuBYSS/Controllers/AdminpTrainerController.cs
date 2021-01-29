using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SporsalonuBYSS.Models;
using SporsalonuBYSS.Repisotory.Concrete;


namespace SporsalonuBYSS.Controllers
{
    public class AdminpTrainerController : Controller
    {
        SporSalonuYSDBEntities db = new SporSalonuYSDBEntities();
        CoachConcrete coachConcrete = new CoachConcrete();

        // GET: AdminpTrainer
        public ActionResult GetTrainer()
        {
            return View(coachConcrete.GetAll());
        }

        public ActionResult AddTrainer()
        {
            return View(coachConcrete.GetAll());
        }
        [HttpPost]
        public ActionResult AddTrainer(Trainer t)
        {
            try
            {
                coachConcrete.Add(t);
                return RedirectToAction("AddTrainer");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Hata", ex);
            }
            return View(t);
        }


        public ActionResult UpdateTrainer()
        {
            return View(coachConcrete.GetAll());
        }
        [HttpPost]
        public ActionResult UpdateTrainer(Trainer trainers)
        {
            try
            {
                coachConcrete.Update(trainers);
                return RedirectToAction("UpdateTrainer");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Hata", ex);
            }
            return View(trainers);
        }

        public ActionResult RemoveTrainer(int id)
        {
            SporSalonuYSDBEntities db = new SporSalonuYSDBEntities();
            Trainer trainers = db.Trainers.FirstOrDefault(trainer => trainer.TrainerID == id);
            return View(trainers);
        }
        [HttpPost]
        public ActionResult RemoveTrainer(Trainer t)
        {
            try
            {
                coachConcrete.Remove(t);
                return RedirectToAction("GetTrainer");
            }
            catch (Exception ex)
            {

                throw ex;
            }
         
        }
    }
}