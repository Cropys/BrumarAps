using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrumarAps.Models
{
    public class MainViewModel
    {
        private readonly BrumarDataModelContainer _db;
        public string CurrentLanguage { get; set; }

        public MainViewModel()
        {
            _db = new BrumarDataModelContainer();
        }

        public string GetText(int textId)
        {
            var value = "";

            try
            {
                if (CurrentLanguage.Equals("EN"))
                {
                    value = _db.LanguageSet.Where(l => l.Id == textId).Select(l => l.English).FirstOrDefault();
                }
                else if (CurrentLanguage.Equals("DK"))
                {
                    value = _db.LanguageSet.Where(l => l.Id == textId).Select(l => l.Danish).FirstOrDefault();
                }
                else if (CurrentLanguage.Equals("IS"))
                {
                    value = _db.LanguageSet.Where(l => l.Id == textId).Select(l => l.Icelandic).FirstOrDefault();
                }
            }
            catch
            {
                value = "DB FAIL";
            }

            return value;
        }
    }
}
