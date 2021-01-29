using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SporsalonuBYSS.Models;

namespace SporsalonuBYSS.Repisotory.Concrete
{
    public class OrderDetailConcrete
    {
        public List<OrderDetail> GetInclude(int id)
        {
            using (SporSalonuYSDBEntities db = new SporSalonuYSDBEntities())
            {
                return db.OrderDetails.Include("Product").Where(od => od.MembersID == id).ToList();
            }
        }
    }
}