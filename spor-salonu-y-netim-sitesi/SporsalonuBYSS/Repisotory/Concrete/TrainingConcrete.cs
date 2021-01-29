using SporsalonuBYSS.Models;
using SporsalonuBYSS.Repisotory.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SporsalonuBYSS.Repisotory.Concrete
{
    public class TrainingConcrete : IRepisotory<Exercis>
    {
        public void Add(Exercis t)
        {
            using (SporSalonuYSDBEntities db = new SporSalonuYSDBEntities())
            {
                db.Exercises.Add(t);
                db.SaveChanges();
            }
        }

        public List<Exercis> GetAll()
        {
            using (SporSalonuYSDBEntities db = new SporSalonuYSDBEntities())
            {
                return db.Exercises.ToList();
            }
        }

        public List<Exercis> GetByID(int id)
        {
            using (SporSalonuYSDBEntities db = new SporSalonuYSDBEntities())
            {
                return db.Exercises.Where(train => train.ExercisesID == id).ToList();
            }
        }

        public Exercis GetID(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Exercis t)
        {
            using (SporSalonuYSDBEntities db = new SporSalonuYSDBEntities())
            {
                db.Exercises.Attach(t);
                db.Entry<Exercis>(t).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void RemoveByID(int id)
        {
            using (SporSalonuYSDBEntities db = new SporSalonuYSDBEntities())
            {
                var getid = db.Exercises.Find(id);
                db.Exercises.Remove(getid);
                db.SaveChanges();
            }
        }

        public void Update(Exercis t)
        {
            using (SporSalonuYSDBEntities db = new SporSalonuYSDBEntities())
            {
                db.Exercises.Attach(t);
                db.Entry<Exercis>(t).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public List<Exercis> GetInclude()
        {
            using (SporSalonuYSDBEntities db = new SporSalonuYSDBEntities())
            {
                return db.Exercises.Include("Trainer").ToList();
            }
        }
    }
}