using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SporsalonuBYSS.App_Class;
using SporsalonuBYSS.Models;
using SporsalonuBYSS.Repisotory.Concrete;

namespace SporsalonuBYSS.Controllers
{
    public class UserpProductsController : Controller
    {
        SporSalonuYSDBEntities db = new SporSalonuYSDBEntities();
        ProductConcrete productConcrete = new ProductConcrete();

        // GET: UserpProducts
        public ActionResult GetUserProducts()
        {
            return View(productConcrete.GetProteinTozu());
        }
        public ActionResult GetUserBCAA()
        {
            return View(productConcrete.GetBCAA());
        }
        public ActionResult GetUserGainer()
        {
            return View(productConcrete.GetGainer());
        }
        //Sepete ekleme işlemini gerçekleştirecek olan metot
        public void AddToBasket(int id)
        {
            SporSalonuYSDBEntities ent = new SporSalonuYSDBEntities();
            SporsalonuBYSS.Models.Basket sepet = new Models.Basket();
            Product p = ent.Products.FirstOrDefault(pr => pr.ProductID == id);
            int userid = Convert.ToInt32(HttpContext.Session["Memberid"]);
            sepet.ProductID = p.ProductID;
            sepet.Price = p.Price;
            sepet.Quantity = 1;
            sepet.SubTotalPrice = p.Price * sepet.Quantity;
            sepet.MembersID = Convert.ToInt32(HttpContext.Session["Memberid"]);
            Sepet basket_management = new Sepet();
            basket_management.AddToDb(sepet);
            BasketWidget();
        }
        //Ajax işlemiyle birlikte sepete ürün eklendiğinde sağ üstte toplam fiyatı 
        //ürün her sepete eklendiğinde gösterecek olan metot
        public PartialViewResult BasketWidget()
        {
            //Sepetin sisteme giriş yapan kullanıcıya göre listelenmesi gerekir.
            //sadece sisteme giriş yapmış olan kullanıcıyı içerisinde barındıran kod satırı
            int userid = Convert.ToInt32(HttpContext.Session["Memberid"]);
            SporSalonuYSDBEntities ent = new SporSalonuYSDBEntities();
            var checkuser = ent.Baskets.FirstOrDefault(b => b.MembersID == userid);
            //Sisteme giriş yapıldıysa giriş yapan kullanıcının sepetini listele
            if (checkuser != null)
            {
                Repisotory.Concrete.BasketConcrete bcon = new Repisotory.Concrete.BasketConcrete();
                return PartialView(bcon.GetByID(Convert.ToInt32(HttpContext.Session["Memberid"])));
            }
            //Sisteme giriş yapılmadıysa sepeti boş bırak
            else
            {
                Repisotory.Concrete.BasketConcrete bcon = new Repisotory.Concrete.BasketConcrete();
                return PartialView();

            }
        }

        public ActionResult ProductDetails(int id)
        {
            var getproducts = db.Products.FirstOrDefault(p => p.ProductID == id);
            return View(getproducts);
        }


    }
}