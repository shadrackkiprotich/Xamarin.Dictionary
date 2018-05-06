using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Firebase.Database.Query;
using Xamarin.Forms;
using Xamarin.Sozluk.Annotations;
using Xamarin.Sozluk.Models;

namespace Xamarin.Sozluk.ViewModels
{
    public class QuestionViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged; 
        private int CorrectAnswerCount { get; set; }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string[] _answers;
        public string[] Answers
        {
            get => _answers;
            set
            {
                _answers = value;
                OnPropertyChanged();
            }
        }
        public Command ClickAnswerCommand => new Command(async (text) =>
        { 
            if ((string)text == QuestionWord.MeaningOfTheWord)
            {
                await ClassUtils.DisplayAlert("Başarılı", "Doğru cevap.", "Devam et");
                this.CorrectAnswerCount++;
#pragma warning disable 4014
                Task.Factory.StartNew(async () =>
                {
                    QuestionWord.CorrectCount++;
                    await ClassUtils.MyFireBaseClient.Child("Words").Child(QuestionWord.ObjectKey)
                        .PutAsync(QuestionWord);

                    ClassUtils.UserInfo.Score += QuestionWord.Point;
                    await ClassUtils.MyFireBaseClient.Child("Users").Child(ClassUtils.UserInfo.ObjectKey)
                        .PutAsync(ClassUtils.UserInfo);
                }); 
#pragma warning restore 4014
            }
            else
                await ClassUtils.DisplayAlert("Hata", "Yanlış cevap verdiniz.", "Devam et");

            if (this.CorrectAnswerCount < 5)
                CreateQuestion();
            else
            {
                await ClassUtils.CloseView();
                await ClassUtils.DisplayAlert("Tamamlandı", "Bu güne ait periyot tamamlandı.", "Tamam");
            }
        });

        private bool _viewVisible;
        public bool NotViewVisible
        {
            get => !_viewVisible;
            set
            {
                _viewVisible = !value;
                OnPropertyChanged();
            }
        }
        public bool ViewVisible
        {
            get => _viewVisible;
            set
            {
                _viewVisible = value;
                OnPropertyChanged();
            }
        }
        private void SetViewVisible(bool value)
        {
            ViewVisible = value;
            NotViewVisible = !value;
        }
        private WordModel _questionWords;
        public WordModel QuestionWord
        {
            get => _questionWords;
            set
            {
                _questionWords = value;
                OnPropertyChanged();
            }
        }
        public QuestionViewModel()
        { 
            CreateQuestion(); 
        }
        public void CreateQuestion()
        {
            Task.Run(async () =>
            {

                var sql = new SqLiteManager();
                Answers=new string[4];
                var words = sql.GetAll().ToList();
                Random rnd = new Random();
                int rndint = rnd.Next(0, words.Count - 1);
                QuestionWord = words[rndint];

                rndint = rnd.Next(0, 3);
                Answers[rndint] = QuestionWord.MeaningOfTheWord; // random put correct answer 
                int counter = 0;
                for (int i = 0; i < 4; i++)
                {
                    if (rndint == i) continue;
                    string wronganswer;
                    do
                    {
                        wronganswer = words[rnd.Next(0, words.Count - 1)].MeaningOfTheWord;
                        if (++counter <= 50) continue;
                        await ClassUtils.DisplayAlert("Hata", "4 den az kelimeniz var! Lütfen yeni kelime ekleyiniz.", "Tamam");
                        break;
                    } while (WrongExists(wronganswer));
                    Answers[i] = wronganswer;
                }
                SetViewVisible(true);
            });
            bool WrongExists(string val)
            {
                for (int i = 0; i < 4; i++)
                    if (Answers[i] == val)
                        return true;
                return false;
            }
        }
    }
}
