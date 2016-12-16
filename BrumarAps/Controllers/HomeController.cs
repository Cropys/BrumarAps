using BrumarAps.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BrumarAps.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //var model = new MainViewModel();

            //if(Request.UserLanguages[0].Equals("da-DK"))
            //{
            //    model.CurrentLanguage = "DK";
            //}
            //else if(Request.UserLanguages[0].Equals("is-IS"))
            //{
            //    model.CurrentLanguage = "IS";
            //}
            //else
            //{
            //    model.CurrentLanguage = "EN";
            //}
            return View();


            //using(var db = new BrumarDataModelContainer())
            //{
            //    CultureInfo ci = new CultureInfo(Request.UserLanguages[0]);

            //    var userStuff = ci.
            //    var newLog = new Logger() { Message = userStuff, Timestamp = DateTime.Now };
            //    db.LoggerSet.Add(newLog);
            //    db.SaveChanges();
            //}
        }

        public JsonResult ContactUs(string Name, string Email, string Message)
        {
            var allofit = "Name: " + Name + ", Email: " + Email + ", Message: " + Message;
            var newLog = new Logger() { Message = "Contact Us form - " + allofit, Timestamp = DateTime.Now };
            var contactF = new ContactForm() { Name = Name, Email = Email, Message = Message };
            using(var db = new BrumarDataModelContainer())
            {
                db.LoggerSet.Add(newLog);
                db.ContactFormSet.Add(contactF);
                db.SaveChanges();
            }
            var success = sendEmail(Name, Email, Message);
            
            if (success) 
            {
                return Json("OK", JsonRequestBehavior.AllowGet);                
            }
            else
            {
                return Json("ERROR", JsonRequestBehavior.AllowGet);
            }
        }

        private bool sendEmail(string name, string email, string custMessage)
        {
            var success = false;
            var newLog = new Logger();
            try
            {
                System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
                message.To.Add("sb@montpro.dk");
                message.Subject = "From Contact Us form on brumar.dk";
                message.From = new System.Net.Mail.MailAddress(email);
                message.Body = custMessage;
                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtprelay.dandomain.dk");
                smtp.Send(message);
                success = true;
                newLog.Message = "Contact form sucessful for" + email;
                newLog.Timestamp = DateTime.Now;
                using(var db = new BrumarDataModelContainer())
                {
                    db.LoggerSet.Add(newLog);
                    db.SaveChanges();
                }
            }
            catch
            {
                newLog.Message = "Failed to send email using contact form! Email: " + email;
                newLog.Timestamp = DateTime.Now;
                using(var db = new BrumarDataModelContainer())
                {
                    db.LoggerSet.Add(newLog);
                    db.SaveChanges();
                }
                success = false;
            }
            return success;
        }

        //public ActionResult Index(string language)
        //{
        //    var model = new MainViewModel();
        //    model.CurrentLanguage = language;
        //    return View(model);
        //}
    }
}