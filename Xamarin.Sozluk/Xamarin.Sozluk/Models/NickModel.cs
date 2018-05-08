using System;

namespace Xamarin.Sozluk.Models
{
    public class NickModel
    { 
        public string Nick{ get; set; }
        public string ObjectKey { get; set; }
        public int Score { get; set; } 
        public DateTime CreationDate { get; set; }
    }
}
