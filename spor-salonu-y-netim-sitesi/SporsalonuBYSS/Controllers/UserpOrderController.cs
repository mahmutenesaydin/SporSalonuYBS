using SporsalonuBYSS.Models;
using SporsalonuBYSS.Repisotory.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SporsalonuBYSS.Controllers
{
    public class UserpOrderController : Controller
    {
        // GET: UserpOrder
        BasketConcrete baskconcrete = new BasketConcrete();
        SporSalonuYSDBEntities db = new SporSalonuYSDBEntities();
        //Giriş yapan kullanıcının sepetindeki ürünleri görüntüler
        public ActionResult UserOrderPage()
        {
            int userid = Convert.ToInt32(HttpContext.Session["Memberid"]);
            return View(baskconcrete.GetincludeByID(userid));
        }
        [HttpPost]
        public ActionResult UserOrderPage(OrderDetail od, Order o)
        {
            var order_d = db.OrderDetails.FirstOrDefault(od1 => od1.ProductID == od.ProductID);
            int userid = Convert.ToInt32(HttpContext.Session["Memberid"]);
            var getbasket = db.Baskets.Where(b => b.MembersID == userid).ToList();
            foreach (var b in getbasket)
            {
                db.OrderDetails.Add(new OrderDetail
                {
                    ProductID = b.ProductID,
                    MembersID = b.MembersID,
                    Quantity = b.Quantity,

                });
                var getid = db.Baskets.Find(b.BasketID);
                db.Baskets.Remove(getid);
                db.SaveChanges();
            }
            db.Orders.Add(new Order
            {
                MembersID = userid,
                ShippedAdress = o.ShippedAdress,
                ShippedCity = o.ShippedCity,
                ShippedDate = DateTime.Now,
                ShippedFirstName = o.ShippedFirstName,
                ShippedLastName = o.ShippedLastName,
                ShippedPhone = o.ShippedPhone,
                ShippedTown = o.ShippedTown
            });
            db.SaveChanges();
            return RedirectToAction("OrderDetailsIndex", "UserpOrder_Details");
        }
        public PartialViewResult SumPrice()
        {
            int userid = Convert.ToInt32(HttpContext.Session["Memberid"]);
            var checkuser = db.Baskets.FirstOrDefault(b => b.MembersID == userid);
            if (checkuser != null)
            {       
                return PartialView(baskconcrete.GetByID(Convert.ToInt32(HttpContext.Session["Memberid"])));
            }
            else
            {
                
                return PartialView();
            }

        }
    }
}