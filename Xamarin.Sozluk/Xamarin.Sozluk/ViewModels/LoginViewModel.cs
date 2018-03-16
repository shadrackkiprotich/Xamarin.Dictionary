using Firebase.Database.Query;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Sozluk.Models;

namespace Xamarin.Sozluk.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private string _entrynick;

        public LoginViewModel()
        {
        }
        public string EntryNick
        {
            get => _entrynick;
            set
            {
                _entrynick = value;
                OnPropertyChanged($"NickChanged");
            }
        }
        public Command LoginControlCommand => new Command(async () =>
        {
            NickModel nickModel = new NickModel() { Nick = EntryNick };
            bool controlEquals = ClassUtils.MyFireBaseClient.Child("Users").OrderByKey().Equals(nickModel);
            if (!controlEquals)
                await ClassUtils.DisplayAlert("Hata", "Bu takma isim daha önce kullanılmış!", "Tammam");
            else
            {
                // ekle.
            }
        });
    }
}
