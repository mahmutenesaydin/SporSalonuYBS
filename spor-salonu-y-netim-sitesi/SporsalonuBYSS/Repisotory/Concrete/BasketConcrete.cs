using SporsalonuBYSS.Models;
using SporsalonuBYSS.Repisotory.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SporsalonuBYSS.Repisotory.Concrete
{
    public class BasketConcrete : IRepisotory<Basket>
    {
        public void Add(Basket t)
        {
            using (SporSalonuYSDBEntities db = new SporSalonuYSDBEntities())
            {
                db.Baskets.Add(t);
                db.SaveChanges();
            }
        }

        public List<Basket> GetAll()
        {
            using (SporSalonuYSDBEntities db = new SporSalonuYSDBEntities())
            {
              return  db.Baskets.ToList();
            }
        }

        public List<Basket> GetByID(int id)
        {
            using (SporSalonuYSDBEntities db = new SporSalonuYSDBEntities())
            {
                return db.Baskets.Where(b => b.MembersID == id).ToList();
            }
           
        }
        public List<Basket> GetincludeByID(int id)
        {
            using (SporSalonuYSDBEntities db = new SporSalonuYSDBEntities())
            {
                return db.Baskets.Include("Product").Where(b => b.MembersID == id).ToList();
            }
        }
        public Basket GetID(int id)
        {
            using (SporSalonuYSDBEntities db = new SporSalonuYSDBEntities())
            {
                return db.Baskets.Find(id);
            }
        }

        public void Remove(Basket t)
        {
            using (SporSalonuYSDBEntities db = new SporSalonuYSDBEntities())
            {
                db.Baskets.Attach(t);
                db.Entry<Basket>(t).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void RemoveByID(int id)
        {
            using (SporSalonuYSDBEntities db = new SporSalonuYSDBEntities())
            {
                var getid = db.Baskets.Find(id);
                db.Baskets.Remove(getid);
                db.SaveChanges();
            }
        }

        public void Update(Basket t)
        {
            using (SporSalonuYSDBEntities db = new SporSalonuYSDBEntities())
            {
                db.Baskets.Attach(t);
                db.Entry<Basket>(t).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}