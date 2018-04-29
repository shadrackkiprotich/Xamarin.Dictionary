using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Sozluk.Annotations;
using Xamarin.Sozluk.View;

namespace Xamarin.Sozluk.ViewModels
{
    public class MainViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        } 
        public string GetTitle => ClassUtils.MainPageTitle;
        public Command OpenQuestionView => new Command(async () => await ClassUtils.OpenView(new QuestionView())); 
        public Command OpenNewWordView=> new Command(async () => await ClassUtils.OpenView(new NewWordView()));
        public Command OpenRankView => new Command(async () => await ClassUtils.OpenView(new RankView()));
        public Command OpenSettingsView => new Command(async () => await ClassUtils.OpenView(new SettingsView()));
    }
}
