using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using Xamarin.Forms;

namespace Xamarin.Sozluk
{
    public class ClassUtils
    {
        public static Color NavigationBarBackgroundColor = Color.FromHex("#B52535");

        private static string FirebaseDbPath => "https://xamarinsozluk.firebaseio.com/"; 
        public static FirebaseClient MyFireBaseClient { get; set; }  
        public ClassUtils()
        {
            MyFireBaseClient = new FirebaseClient(FirebaseDbPath); 
        } 
        public static async Task OpenView(Page page)
        {
            await Application.Current.MainPage.Navigation.PushAsync(page);
        }

        public static async Task DisplayAlert(string title, string message, string cancel) => await Application.Current.MainPage.DisplayAlert(title, message, cancel);
        public static async Task DisplayAlert(string title, string message, string accept, string cancel) => await Application.Current.MainPage.DisplayAlert(title, message,accept,cancel);

    }
     
}
