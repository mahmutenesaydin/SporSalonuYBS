using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SporsalonuBYSS.Models;
using SporsalonuBYSS.Repisotory.Concrete;

namespace SporsalonuBYSS.App_Class
{
    public class Sepet
    {
        public void AddToDb(Basket bitem2)
        {
            BasketConcrete basketcon = new BasketConcrete();
            using (SporSalonuYSDBEntities db = new SporSalonuYSDBEntities())
            {
                int value = db.Baskets.Count();
                if (value >= 1)
                {
                    //Parametre olarak sepete ekleyeceğimiz ürünün id si ile veri tabandaki ürünün id'sini 
                    //eşitliyor
                    var fillsession2 = db.Baskets.FirstOrDefault(b => b.ProductID == bitem2.ProductID
                      && b.MembersID == bitem2.MembersID);
                    //Veri tabanına daha önce ürün eklenmişse ürünün miktarı arttırılır
                    if (fillsession2 != null)
                    {
                        SporsalonuBYSS.Models.Basket b = basketcon.GetID(fillsession2.BasketID);
                        b.BasketID = fillsession2.BasketID;

                        b.MembersID = bitem2.MembersID;
                        b.Price = bitem2.Price;
                        b.ProductID = bitem2.ProductID;
                        b.Quantity = b.Quantity + bitem2.Quantity;
                        b.SubTotalPrice = bitem2.SubTotalPrice * b.Quantity;
                        basketcon.Update(b);
                    }
                    //Eğer ürün daha önce sepete eklenmemişse bu satır çalışır
                    else
                    {
                        //Ürünü tabloya ekler
                        basketcon.Add(bitem2);
                    }
                    //Eğer database de eklediğimiz ürün daha önce sepete  eklenmemişse bu kod satırı çalışıyor
                    //Sepette önceden ürün eklenmemişse bu satır çalışacak
                }
                //Eğer sepet tablosunda hiç ürün yoksa bu satır çalışacak
                else
                {
                    SporsalonuBYSS.Models.Basket basket = new Models.Basket();
                    //Sepet tablosuna seçilen ürünü ekler
                    basketcon.Add(bitem2);
                }

            }
        }
        //Ürün sepette varsa ve kullanıcı sepetteki ürünün miktarını güncellemek(arttırmak) isterse
        //Bu metot çalışacak
        public void UpdateBasket(int basketid,int productid)
        {
            //Güncelleme yani ürünün miktarını arttırma işlemi
            using (SporSalonuYSDBEntities db = new SporSalonuYSDBEntities())
            {
                BasketConcrete basketcon = new BasketConcrete();
                SporsalonuBYSS.Models.Basket b = basketcon.GetID(basketid);
                b.BasketID = basketid;
                b.ProductID = productid;
                b.Quantity = b.Quantity + 1;
                b.SubTotalPrice = b.Price * b.Quantity;
                basketcon.Update(b);
            }
        }
        //Ürün sepette varsa ve kullanıcı sepetteki ürünün miktarını güncellemek(azaltmak) isterse
        //Bu metot çalışacak
        public void UpdateBasket_R(int basketid,int productid)
        {  
            //Güncelleme yani ürünün miktarını azaltma işlemi
            using (SporSalonuYSDBEntities db = new SporSalonuYSDBEntities())
            {
                BasketConcrete basketcon = new BasketConcrete();
                SporsalonuBYSS.Models.Basket b = basketcon.GetID(basketid);
                b.BasketID = basketid;
                b.ProductID = productid;
                b.Quantity = b.Quantity - 1;
                b.SubTotalPrice = b.Price * b.Quantity;
                basketcon.Update(b);
            }
        }
    }
}