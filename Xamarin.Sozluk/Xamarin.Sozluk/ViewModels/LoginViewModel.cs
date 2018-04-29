using Firebase.Database;
using Firebase.Database.Query;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Sozluk.Models;
using Xamarin.Sozluk.Views;

namespace Xamarin.Sozluk.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public string GetTitle => ClassUtils.MainPageTitle;
        private string _entrynick;
        private bool _activityInd;
        public string EntryNick
        {
            get => _entrynick;
            set
            {
                _entrynick = value;
                OnPropertyChanged();
            }
        }
        public bool ActivityInd
        {
            get => _activityInd;
            set
            {
                _activityInd = value;
                OnPropertyChanged();
            }
        }
        public Command LoginControlCommand => new Command(async () =>
        {
            try
            {
                ActivityInd = true;
                string conNick = EntryNick;
                List<FirebaseObject<NickModel>> list =
                    (from x in (await ClassUtils.MyFireBaseClient.Child("Users").OnceAsync<NickModel>())
                        where x.Object.Nick == conNick
                        select x).ToList();

                if (list.Count > 0)
                    await ClassUtils.DisplayAlert("Error", "This username already exists!", "OK");
                else
                {
                    NickModel newNick = new NickModel {Nick = EntryNick};
                    var addedObject = await ClassUtils.MyFireBaseClient.Child("Users").PostAsync(newNick);

                    if (Application.Current.Properties.Count > 0)
                        Application.Current.Properties.Clear();
                    Application.Current.Properties.Add("UserKey", addedObject.Key);
                    Application.Current.Properties.Add("UserNick", newNick.Nick);
                    await Application.Current.SavePropertiesAsync();

                    ClassUtils.SetMainPage(new MainView());
                }
            }
            catch (System.Exception exception)
            {
                await ClassUtils.DisplayAlert("Error", $"Unkown error : {exception.Message}", "OK");
            }
            finally
            {
                ActivityInd = false;
            }
        });

    }
}
