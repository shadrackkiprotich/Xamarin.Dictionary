
using Firebase.Database;
using Xamarin.Forms;
using Xamarin.Sozluk.Models;
using Xamarin.Sozluk.View;
using Xamarin.Sozluk.Views;

namespace Xamarin.Sozluk
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent(); 
            ClassUtils.MyFireBaseClient = new FirebaseClient(ClassUtils.FirebaseDbPath); 
            if (Application.Current.Properties.Count > 0)
            {
                ClassUtils.UserInfo = new NickModel()
                {
                    ObjectKey = Application.Current.Properties["UserKey"] as string,
                    Nick = Application.Current.Properties["UserNick"] as string
                };
                ClassUtils.SetMainPage(new MainPage());
            }
            else
                ClassUtils.SetMainPage(new LoginView());
        }
    

    protected override void OnStart()
    {
        // Handle when your app starts
    }

    protected override void OnSleep()
    {
        // Handle when your app sleeps
    }

    protected override void OnResume()
    {
        // Handle when your app resumes
    }
}
}
