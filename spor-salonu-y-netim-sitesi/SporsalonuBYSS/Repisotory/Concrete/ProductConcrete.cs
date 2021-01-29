using SporsalonuBYSS.Models;
using SporsalonuBYSS.Repisotory.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SporsalonuBYSS.Repisotory.Concrete
{
    public class ProductConcrete : IRepisotory<Product>
    {
        public void Add(Product t)
        {
            using (SporSalonuYSDBEntities db = new SporSalonuYSDBEntities())
            {
                db.Products.Add(t);
                db.SaveChanges();
            }
        }

        public List<Product> GetAll()
        {
            using (SporSalonuYSDBEntities db = new SporSalonuYSDBEntities())
            {
                return db.Products.ToList();
            }
        }
        public List<Product> GetProteinTozu()
        {
            using (SporSalonuYSDBEntities db = new SporSalonuYSDBEntities())
            {
                return db.Products.Where(u => u.CategoryID == 1).ToList();

            }
        }
        public List<Product> GetBCAA()
        {
            using (SporSalonuYSDBEntities db = new SporSalonuYSDBEntities())
            {
                return db.Products.Where(u => u.CategoryID == 2).ToList();

            }
        }

        public List<Product> GetGainer()
        {
            using (SporSalonuYSDBEntities db = new SporSalonuYSDBEntities())
            {
                return db.Products.Where(u => u.CategoryID == 3).ToList();

            }
        }
        public List<Product> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public Product GetID(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Product t)
        {
            using (SporSalonuYSDBEntities db = new SporSalonuYSDBEntities())
            {
                db.Products.Attach(t);
                db.Entry<Product>(t).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void RemoveByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Product t)
        {
            using (SporSalonuYSDBEntities db = new SporSalonuYSDBEntities())
            {
                db.Products.Attach(t);
                db.Entry<Product>(t).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }


        public List<Product> GetInclude()
        {
            using (SporSalonuYSDBEntities db = new SporSalonuYSDBEntities())
            {
                return db.Products.Include("Category").ToList();
            }
        }
    }
}