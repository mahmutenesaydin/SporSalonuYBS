using SporsalonuBYSS.Models;
using SporsalonuBYSS.Repisotory.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SporsalonuBYSS.Controllers
{
    public class AdminpProductsController : Controller
    {
        ProductConcrete prodConcrete = new ProductConcrete();
        SporSalonuYSDBEntities db = new SporSalonuYSDBEntities();

        public ActionResult GetProducts()
        {
            return View(prodConcrete.GetInclude());
        }

        public ActionResult AddProducts()
        {
            return View(prodConcrete.GetAll());
        }
        [HttpPost]
        public ActionResult AddProducts(Product p)
        {
            try
            {
                prodConcrete.Add(p);
                return RedirectToAction("AddProducts");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Hata", ex);
            }
            return View(p);
        }

        public ActionResult UpdateProducts()
        {
            ViewBag.Category = db.Categories.ToList();
            ViewBag.Dealer = db.Dealers.ToList();
            return View(prodConcrete.GetInclude());
        }


        [HttpPost]
        public ActionResult UpdateProducts(Product prod)
        {
            try
            {
                prodConcrete.Update(prod);
                return RedirectToAction("UpdateProducts");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Hata", ex);
            }
            return View(prod);
        }


        public ActionResult RemoveProducts(int id)
        {
            SporSalonuYSDBEntities db = new SporSalonuYSDBEntities();
            Product product = db.Products.FirstOrDefault(product1 => product1.ProductID == id);
            return View(product);
        }
        [HttpPost]
        public ActionResult RemoveProducts(Product p)
        {
            try
            {
                prodConcrete.Remove(p);
                return RedirectToAction("GetProducts");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            
        }
    }
}