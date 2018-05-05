using System;
using System.Collections.Generic;
using Firebase.Database.Query;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reactive.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Firebase.Database;
using Xamarin.Forms;
using Xamarin.Sozluk.Annotations;
using Xamarin.Sozluk.Models;
using Xamarin.Sozluk.Views;

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
        private ObservableCollection<WordModel> _viewWordList = new ObservableCollection<WordModel>();
        public ObservableCollection<WordModel> ViewWordList
        {
            get => _viewWordList;
            set
            {
                ListRefreshing = true;
                _viewWordList = value;
                OnPropertyChanged();
                ListRefreshing = false;
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
        public Command AddWordToQueue => new Command(async () =>
        { 
            if (SelectedModel != null)
            {
                var sql = new SqLiteManager();
                var item = sql.GetAll().ToList();
                if (!sql.Exists(SelectedModel.ObjectKey))
                    sql.Insert(SelectedModel);
                ViewWordList.Remove(SelectedModel);
                sql.Dispose();
            }
            else
                await ClassUtils.DisplayAlert("Hata", "Kelime Seçmediniz!", "Tamam");
        });
        private WordModel _selectedModel; 
        public WordModel SelectedModel
        {
            get => _selectedModel;
            set
            {
                _selectedModel = value;
                OnPropertyChanged();
            }
        }
        public NewWordViewModel()
        { 
            Task.Run(() =>
            {
                var items = ClassUtils.MyFireBaseClient.Child("Words").OrderByKey().OnceAsync<WordModel>(); // all words come
                ListRefreshing = true;
                var sql = new SqLiteManager();
                foreach (var d in items.Result)
                { 
                    if (!sql.Exists(d.Key)) 
                        ViewWordList.Add(new WordModel()
                        {
                            Word = d.Object.Word,
                            MeaningOfTheWord = d.Object.MeaningOfTheWord,
                            NumberOfViews = d.Object.NumberOfViews,
                            CorrectCount = d.Object.CorrectCount,
                            ObjectKey = d.Key
                        });
                }
                ListRefreshing = false;
            });
        }
        //public async Task addtestwords()
        //{
        //    var newWord = new WordModel()
        //    {
        //        Word = "about",
        //        MeaningOfTheWord = "hakkında",
        //        CorrectCount = 0,
        //        NumberOfViews = 0
        //    };

        //    await ClassUtils.MyFireBaseClient.Child("Words").PostAsync(newWord);

        //    newWord = new WordModel()
        //    {
        //        Word = "activity",
        //        MeaningOfTheWord = "aktivite",
        //        CorrectCount = 0,
        //        NumberOfViews = 0
        //    };
        //    await ClassUtils.MyFireBaseClient.Child("Words").PostAsync(newWord);

        //    newWord = new WordModel()
        //    {
        //        Word = "agree",
        //        MeaningOfTheWord = "anlaşmak",
        //        CorrectCount = 0,
        //        NumberOfViews = 0
        //    };
        //    await ClassUtils.MyFireBaseClient.Child("Words").PostAsync(newWord);

        //    newWord = new WordModel()
        //    {
        //        Word = "add",
        //        MeaningOfTheWord = "eklemek",
        //        CorrectCount = 0,
        //        NumberOfViews = 0
        //    };
        //    await ClassUtils.MyFireBaseClient.Child("Words").PostAsync(newWord);
        //}
    }
}
