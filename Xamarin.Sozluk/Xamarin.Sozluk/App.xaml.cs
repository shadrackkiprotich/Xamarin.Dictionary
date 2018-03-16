
using Xamarin.Forms;
using Xamarin.Sozluk.View;

namespace Xamarin.Sozluk
{
    public partial class App : Application
	{
		public App ()
		{
			InitializeComponent(); 
			MainPage = new NavigationPage(root:new LoginView())
			{
                BarBackgroundColor = ClassUtils.NavigationBarBackgroundColor,
                BarTextColor = Color.White
			};
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
