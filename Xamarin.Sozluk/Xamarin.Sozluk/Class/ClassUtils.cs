using System.Threading.Tasks;
using Xamarin.Forms;

namespace Xamarin.Sozluk
{
    public class ClassUtils
    {
        public static Color NavigationBarBackgroundColor = Color.FromHex("#B52535");
        public static async Task OpenView(Page page)
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(page);
        }
    }
     
}
