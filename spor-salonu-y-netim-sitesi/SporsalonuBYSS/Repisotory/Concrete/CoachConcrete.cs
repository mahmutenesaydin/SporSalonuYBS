using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SporsalonuBYSS.Repisotory.Abstract;
using SporsalonuBYSS.Models;

namespace SporsalonuBYSS.Repisotory.Concrete
{
    public class CoachConcrete : IRepisotory<Trainer>
    {
        public void Add(Trainer t)
        {
            using (SporSalonuYSDBEntities db = new SporSalonuYSDBEntities())
            {
                db.Trainers.Add(t);
                db.SaveChanges();
            }
        }

        public List<Trainer> GetAll()
        {
            using (SporSalonuYSDBEntities db = new SporSalonuYSDBEntities())
            {
                return db.Trainers.ToList();
            }
        }

        public List<Trainer> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public Trainer GetID(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Trainer t)
        {
            using (SporSalonuYSDBEntities db = new SporSalonuYSDBEntities())
            {
                db.Trainers.Attach(t);
                db.Entry<Trainer>(t).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void RemoveByID(int id)
        {
            using (SporSalonuYSDBEntities db = new SporSalonuYSDBEntities())
            {
                var getid = db.Trainers.Find(id);
                db.Trainers.Remove(getid);
                db.SaveChanges();
            }
        }

        public void Update(Trainer t)
        {
            using (SporSalonuYSDBEntities db = new SporSalonuYSDBEntities())
            {
                db.Trainers.Attach(t);
                db.Entry<Trainer>(t).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
        public List<Trainer> GetInclude()
        {
            using (SporSalonuYSDBEntities db = new SporSalonuYSDBEntities())
            {
                return db.Trainers.Include("Dealer").ToList();
            }
        }
    }
}