using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Sozluk.Annotations;
using Xamarin.Sozluk.Models;

namespace Xamarin.Sozluk.ViewModels
{
    public class NewWordViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged; 
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public string GetTitle => "Yeni kelime ekle";
        private ObservableCollection<WordModel> _viewWordList=new ObservableCollection<WordModel>();
        public ObservableCollection<WordModel> ViewWordList
        {
            get => _viewWordList;
            set => _viewWordList = value;
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

        public NewWordViewModel()
        {
            ViewWordList.Add(new WordModel(){Word = "book", MeaningOfTheWord = "kitap"});
            ViewWordList.Add(new WordModel() { Word = "book", MeaningOfTheWord = "kitap" });
            ViewWordList.Add(new WordModel() { Word = "book", MeaningOfTheWord = "kitap" });
            ViewWordList.Add(new WordModel() { Word = "book", MeaningOfTheWord = "kitap" });
            ViewWordList.Add(new WordModel() { Word = "book", MeaningOfTheWord = "kitap" });

        }
    }
}
