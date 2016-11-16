using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrumarAps.Models
{
    public class TranslateViewModel
    {
        public List<TranslateText> Original { get; set; }
        public List<TranslateText> NewLanguage { get; set; }
        public List<TranslateText> English { get; set; }

        public TranslateViewModel()
        {
            Original = new List<TranslateText>();
            NewLanguage = new List<TranslateText>();
            English = new List<TranslateText>();
        }
    }

    public class TranslateText
    {
        public int ID { get; set; }
        public string TextValue { get; set; }
    }
}