using BrumarAps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BrumarAps.Controllers
{
    public class TranslateController : Controller
    {

        private readonly BrumarDataModelContainer _db = new BrumarDataModelContainer();

        // GET: Translate
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Danish()
        {
            var model = new TranslateViewModel();
            var everything = _db.LanguageSet.ToList();

            foreach (var item in everything)
            {
                model.Original.Add(new TranslateText() { ID = item.Id, TextValue= item.Danish  });
                model.English.Add(new TranslateText() { ID = item.Id, TextValue = item.English });
            }
            
            return View(model);
        }

        public ActionResult English()
        {
            var model = new TranslateViewModel();

            var everything = _db.LanguageSet.ToList();

            foreach (var item in everything)
            {
                model.English.Add(new TranslateText() { ID = item.Id, TextValue = item.English });
            }

            return View(model);
        }

        public JsonResult UpdateEnglish(List<int> ids ,List<string> newTexts, string AuthCode)
        {
            if(AuthCode.Equals("ict2014!"))
            {
                var some = _db.LanguageSet.Where(x => ids.Contains(x.Id)).ToList();

                foreach (var item in newTexts)
                {
                    some.ForEach(a => a.English = item);
                }
                try
                {
                    _db.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                {
                    Exception raise = dbEx;
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            string message = string.Format("{0}:{1}",
                                validationErrors.Entry.Entity.ToString(),
                                validationError.ErrorMessage);
                            // raise a new exception nesting
                            // the current instance as InnerException
                            raise = new InvalidOperationException(message, raise);
                        }
                    }
                    throw raise;
                }

                return Json("Success", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("WRONG", JsonRequestBehavior.AllowGet);
            }
            
        }

        public JsonResult UpdateDanish(List<int> ids, List<string> newTexts, string AuthCode)
        {
            if (AuthCode.Equals("ict2014!"))
            {
                var some = _db.LanguageSet.Where(x => ids.Contains(x.Id)).ToList();

                foreach (var item in newTexts)
                {
                    some.ForEach(a => a.Danish = item);
                }
                try
                {
                    _db.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                {
                    Exception raise = dbEx;
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            string message = string.Format("{0}:{1}",
                                validationErrors.Entry.Entity.ToString(),
                                validationError.ErrorMessage);
                            // raise a new exception nesting
                            // the current instance as InnerException
                            raise = new InvalidOperationException(message, raise);
                        }
                    }
                    throw raise;
                }

                return Json("Success", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("WRONG", JsonRequestBehavior.AllowGet);
            }
        }
    }
}