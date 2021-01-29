using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SporsalonuBYSS.Repisotory.Concrete;
using SporsalonuBYSS.Models;

namespace SporsalonuBYSS.Controllers
{
    public class AdminpTrainingController : Controller
    {
        TrainingConcrete trainConcrete = new TrainingConcrete();
        SporSalonuYSDBEntities db = new SporSalonuYSDBEntities();

        // GET: AdminpTraining
        public ActionResult ListTraining()
        {
            return View(trainConcrete.GetAll());
        }

        public ActionResult AddTraining()
        {
            ViewBag.Trainer = db.Trainers.ToList();
            return View(trainConcrete.GetInclude());
        }

        [HttpPost]
        public ActionResult AddTraining(Exercis e)
        {
            try
            {
                trainConcrete.Add(e);
                return RedirectToAction("AddTraining");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Hata", ex);
            }
            return View(e);
        }

        public ActionResult UpdateTraining()
        {
            ViewBag.Trainer = db.Trainers.ToList();
            return View(trainConcrete.GetInclude());
        }

        [HttpPost]
        public ActionResult UpdateTraining(Exercis e)
        {
            try
            {
                trainConcrete.Update(e);
                return RedirectToAction("UpdateTraining");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Hata", ex);
            }
            return View(e);
        }

        public ActionResult RemoveTraining(int id)
        {
            Exercis training = db.Exercises.FirstOrDefault(e => e.ExercisesID == id);
            return View(training);
        }
        [HttpPost]
        public ActionResult RemoveTraining(Exercis training)
        {
            try
            {
                trainConcrete.Remove(training);
                return RedirectToAction("ListTraining");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}