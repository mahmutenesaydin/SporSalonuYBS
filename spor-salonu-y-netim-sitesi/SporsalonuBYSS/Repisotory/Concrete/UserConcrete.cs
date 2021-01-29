using SporsalonuBYSS.Models;
using SporsalonuBYSS.Repisotory.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SporsalonuBYSS.Repisotory.Concrete
{
    public class UserConcrete : IRepisotory<User>
    {
        public void Add(User t)
        {
            using (SporSalonuYSDBEntities db = new SporSalonuYSDBEntities())
            {
                db.Users.Add(t);
                db.SaveChanges();
            }
        }

        public List<User> GetAll()
        {
            using (SporSalonuYSDBEntities db = new SporSalonuYSDBEntities())
            {
                return db.Users.ToList();
            }
        }

        public List<User> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public User GetID(int id)
        {
            using (SporSalonuYSDBEntities db = new SporSalonuYSDBEntities())
            {
                return db.Users.Find(id);
            }
        }

        public void Remove(User t)
        {
            using (SporSalonuYSDBEntities db = new SporSalonuYSDBEntities())
            {
                db.Users.Attach(t);
                db.Entry<User>(t).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void RemoveByID(int id)
        {
            using (SporSalonuYSDBEntities db = new SporSalonuYSDBEntities())
            {
                var getid = db.Users.Find(id);
                db.Users.Remove(getid);
                db.SaveChanges();
            }
        }

        public void Update(User t)
        {
            using (SporSalonuYSDBEntities db = new SporSalonuYSDBEntities())
            {
                db.Users.Attach(t);
                db.Entry<User>(t).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public List<User> GetInclude()
        {
            using (SporSalonuYSDBEntities db = new SporSalonuYSDBEntities())
            {
                return db.Users.Include("Role").ToList();
            }
        }
    }
}