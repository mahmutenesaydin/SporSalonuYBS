using SporsalonuBYSS.App_Class;
using SporsalonuBYSS.Models;
using SporsalonuBYSS.Repisotory.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SporsalonuBYSS.Controllers
{
    public class UserpBasketController : Controller
    {
        // GET: UserpBasket
        SporSalonuYSDBEntities db = new SporSalonuYSDBEntities();
        BasketConcrete baskconcrete = new BasketConcrete();
        public ActionResult BasketIndex()
        {
            int userid = Convert.ToInt32(HttpContext.Session["Memberid"]);
            return View(baskconcrete.GetincludeByID(userid));
        }
        public ActionResult DeleteBasket(int id)
        {
            Basket bask = db.Baskets.Include("Product").FirstOrDefault(b => b.BasketID == id);
            return View(bask);
        }
        [HttpPost]
        public ActionResult Deletebasket(Basket b)
        {
            baskconcrete.Remove(b);
            return RedirectToAction("BasketIndex");
        }
        public void UpdateBask(int basketid, int productid)
        {
            Sepet basket_management = new Sepet();
            SporSalonuYSDBEntities ent = new SporSalonuYSDBEntities();
            int userid = Convert.ToInt32(HttpContext.Session["Memberid"]);
            SporsalonuBYSS.Models.Basket basket = ent.Baskets.FirstOrDefault(b => b.MembersID == userid);
            basket.ProductID = productid;

            basket.BasketID = basketid;
            basket_management.UpdateBasket(basket.BasketID, basket.ProductID);
            ProductSumTotalQuery();
            ProductTotalQuery();

        }
        public void UpdateBask_R(int basketid,int productid)
        {
            Sepet basket_management = new Sepet();
            SporSalonuYSDBEntities ent = new SporSalonuYSDBEntities();
            int userid = Convert.ToInt32(HttpContext.Session["Memberid"]);
            SporsalonuBYSS.Models.Basket basket = ent.Baskets.FirstOrDefault(b => b.MembersID == userid);
            basket.ProductID = productid;
            basket.BasketID = basketid;
            basket_management.UpdateBasket_R(basket.BasketID, basket.ProductID);
            ProductSumTotalQuery();
            ProductTotalQuery();
        }
        public PartialViewResult ProductTotalQuery()
        {
            int userid = Convert.ToInt32(HttpContext.Session["Memberid"]);
            SporSalonuYSDBEntities ent = new SporSalonuYSDBEntities();
            var checkuser = ent.Baskets.FirstOrDefault(b => b.MembersID == userid);
            if (checkuser != null)
            {
                Repisotory.Concrete.BasketConcrete bcon = new Repisotory.Concrete.BasketConcrete();
                return PartialView(bcon.GetByID(Convert.ToInt32(HttpContext.Session["Memberid"])));
            }
            else
            {
                Repisotory.Concrete.BasketConcrete bcon = new Repisotory.Concrete.BasketConcrete();
                return PartialView();
            }
        }
        public PartialViewResult ProductSumTotalQuery()
        {
            int userid = Convert.ToInt32(HttpContext.Session["Memberid"]);
            SporSalonuYSDBEntities ent = new SporSalonuYSDBEntities();
            var checkuser = ent.Baskets.FirstOrDefault(b => b.MembersID == userid);
            if (checkuser != null)
            {
                Repisotory.Concrete.BasketConcrete bcon = new Repisotory.Concrete.BasketConcrete();
                return PartialView(bcon.GetByID(Convert.ToInt32(HttpContext.Session["Memberid"])));
            }
            else
            {
                Repisotory.Concrete.BasketConcrete bcon = new Repisotory.Concrete.BasketConcrete();
                return PartialView();

            }
        }
    }
}