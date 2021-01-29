using SporsalonuBYSS.Models;
using SporsalonuBYSS.Repisotory.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace SporsalonuBYSS.Controllers
{
    public class ForgotPasswordController : Controller
    {
        UserConcrete userConcrete = new UserConcrete();
        SporSalonuYSDBEntities db = new SporSalonuYSDBEntities();

        [HttpGet]
        public ActionResult ForgotPasswordPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPasswordPage(User u)
        {
            var model = db.Users.Where(x => x.EMail == u.EMail).FirstOrDefault();
            if (model != null)
            {
                Guid random = Guid.NewGuid();
                model.Password = random.ToString().Substring(0, 4);
                db.SaveChanges();
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("stormgym001@gmail.com", "Şifre Sıfırlama");
                mail.To.Add(model.EMail);
                mail.IsBodyHtml = true;
                mail.Subject = "Şifre Değiştirme İsteği";
                mail.Body += "Kullanıcı Adınız=" + model.Username + "<br/> Şifreniz= " + model.Password;
                NetworkCredential net = new NetworkCredential("stormgym001@gmail.com", "dalgadalga");
                client.Credentials = net;
                client.Send(mail);
                return RedirectToAction("LogonPage", "Login");
            }
            ViewBag.hata = "Böyle bir E-Mail adresi bulunamadı";
            return View();
        }
    }
}