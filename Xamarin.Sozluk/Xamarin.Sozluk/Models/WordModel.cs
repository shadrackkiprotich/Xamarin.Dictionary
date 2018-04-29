using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin.Sozluk.Models
{
    public class WordModel
    {
        public string ObjectKey { get; set; }
        public string Word { get; set; } // english
        public string MeaningOfTheWord { get; set; } // turkish 
        public int NumberOfViews { get; set; }
        public int CorrectCount { get; set; }
    }
}
