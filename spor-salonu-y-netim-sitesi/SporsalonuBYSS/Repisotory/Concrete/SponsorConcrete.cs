using SporsalonuBYSS.Models;
using SporsalonuBYSS.Repisotory.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SporsalonuBYSS.Repisotory.Concrete
{
    public class SponsorConcrete : IRepisotory<Sponsor>
    {
        public void Add(Sponsor t)
        {
            using (SporSalonuYSDBEntities db = new SporSalonuYSDBEntities())
            {
                db.Sponsors.Add(t);
                db.SaveChanges();
            }
        }

        public List<Sponsor> GetAll()
        {
            using (SporSalonuYSDBEntities db = new SporSalonuYSDBEntities())
            {
                return db.Sponsors.ToList();
            }
        }

        public List<Sponsor> GetByID(int id)
        {
            using (SporSalonuYSDBEntities db = new SporSalonuYSDBEntities())
            {
                return db.Sponsors.Where(s => s.DealerID == id).ToList();
            }
        }

        public Sponsor GetID(int id)
        {
            using (SporSalonuYSDBEntities db = new SporSalonuYSDBEntities())
            {
                return db.Sponsors.Find(id);
            }
        }

        public void Remove(Sponsor t)
        {
            using (SporSalonuYSDBEntities db = new SporSalonuYSDBEntities())
            {
                db.Sponsors.Attach(t);
                db.Entry<Sponsor>(t).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void RemoveByID(int id)
        {
            using (SporSalonuYSDBEntities db = new SporSalonuYSDBEntities())
            {
                var idbul = db.Sponsors.Find(id);
                db.Sponsors.Remove(idbul);
                db.SaveChanges();
            }
        }

        public void Update(Sponsor t)
        {
            using (SporSalonuYSDBEntities db = new SporSalonuYSDBEntities())
            {
                db.Sponsors.Attach(t);
                db.Entry<Sponsor>(t).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
        public List<Sponsor> GetIncludeList()
        {
            using (SporSalonuYSDBEntities db = new SporSalonuYSDBEntities())
            {
                return db.Sponsors.Include("Dealer").ToList();
            }
        }
    }
}