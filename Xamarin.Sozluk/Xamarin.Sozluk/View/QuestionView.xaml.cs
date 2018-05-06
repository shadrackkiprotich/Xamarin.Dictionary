
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin.Sozluk.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class QuestionView : ContentPage
	{
		public QuestionView ()
		{
            NavigationPage.SetHasBackButton(this,false);
			InitializeComponent ();
		}

	    protected override bool OnBackButtonPressed()
	    {
	        return false;
	    }
	}
}