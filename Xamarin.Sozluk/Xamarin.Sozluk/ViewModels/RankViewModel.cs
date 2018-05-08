using Firebase.Database.Query;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Sozluk.Annotations;
using Xamarin.Sozluk.Models;
namespace Xamarin.Sozluk.ViewModels
{
    public class RankViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private ObservableCollection<NickModel> _nicks=new ObservableCollection<NickModel>();
        public ObservableCollection<NickModel> Nicks
        {
            get => _nicks;
            set
            {
                _nicks = value;
                OnPropertyChanged();
            }
        } 
        private bool _listRefresh; 
        public bool ListRefreshing
        {
            get => _listRefresh; 
            set
            {
                _listRefresh = value;
                OnPropertyChanged();
            }
        } 
        public RankViewModel()
        {
            Task.Run(() =>
            {
                ListRefreshing = true;
                var items = ClassUtils.MyFireBaseClient.Child("Users").OrderByKey().OnceAsync<NickModel>();
                foreach (var d in items.Result)
                {
                    Nicks.Add(new NickModel()
                    {
                        Nick = d.Object.Nick,
                        Score = d.Object.Score
                    });
                }
                Nicks = new ObservableCollection<NickModel>(Nicks.OrderByDescending(x=>x.Score));
                ListRefreshing = false;
            });
        }
    }
}
