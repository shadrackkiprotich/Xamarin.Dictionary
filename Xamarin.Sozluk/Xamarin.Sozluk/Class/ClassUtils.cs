using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using Xamarin.Forms;
using Xamarin.Sozluk.Models;

namespace Xamarin.Sozluk
{
    public class ClassUtils
    {
        public static NickModel UserInfo { get; set; }

        public static Color NavigationBarBackgroundColor = Color.FromHex("#B52535"); 
        public static string FirebaseDbPath => "https://xamarinsozluk.firebaseio.com/"; 
        public static FirebaseClient MyFireBaseClient { get; set; }
        public static async Task OpenView(Page page)
        {
            await Application.Current.MainPage.Navigation.PushAsync(page);
        } 
        public static async Task CloseView()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
        public static async Task DisplayAlert(string title, string message, string cancel) => await Application.Current.MainPage.DisplayAlert(title, message, cancel);
        public static async Task DisplayAlert(string title, string message, string accept, string cancel) => await Application.Current.MainPage.DisplayAlert(title, message,accept,cancel);
        public static void SetMainPage(Page page)
        {  
            Application.Current.MainPage = new NavigationPage(root: page)
            {
                BarBackgroundColor = ClassUtils.NavigationBarBackgroundColor,
                BarTextColor = Color.White
            };
        }
    }
     
}
