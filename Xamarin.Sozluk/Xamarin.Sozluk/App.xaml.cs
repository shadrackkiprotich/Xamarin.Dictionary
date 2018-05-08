
using Firebase.Database;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Sozluk.Models;
using Xamarin.Sozluk.View;
using Xamarin.Sozluk.Views;

namespace Xamarin.Sozluk
{
    public partial class App 
    {
        public App()
        {
            InitializeComponent();
            ClassUtils.MyFireBaseClient = new FirebaseClient(ClassUtils.FirebaseDbPath);
            if (Current.Properties.Count > 0)
            {
                Task.Run(() =>
                {
                    string nickKey = Current.Properties["UserKey"] as string;
                    var item = ClassUtils.MyFireBaseClient.Child("Users").OrderByKey()
                        .StartAt(nickKey).LimitToFirst(1).OnceAsync<NickModel>();
                    var d = item.Result.ToList()[0];
                    ClassUtils.UserInfo = new NickModel()
                    {
                        Nick = d.Object.Nick,
                        ObjectKey = d.Object.ObjectKey,
                        Score = d.Object.Score
                    };
                }); 
                ClassUtils.SetMainPage(new MainView());
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
