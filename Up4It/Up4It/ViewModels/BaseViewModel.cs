using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Up4It.Repositories;
using Xamarin.Forms;

namespace Up4It.ViewModels
{
    public class BaseViewModel<T> : BaseViewModel where T : class, new()
    {

        static readonly MethodInfo GetDependency;

        static BaseViewModel()
        {
            var repoType = Up4ItApp.TypeMap[typeof(T)];
            var getMethod = typeof(DependencyService).GetRuntimeMethods().Single(m => m.Name.Equals("Get"));
            GetDependency = getMethod.MakeGenericMethod(repoType);
        }

        const string IconFormat = "{0}.png";

        public BaseViewModel()
        {
            Title = typeof(T).Name;
            Icon = string.Format(IconFormat, Title).ToLower();
            Models = new System.Collections.ObjectModel.ObservableCollection<T>();
        }

        public System.Collections.ObjectModel.ObservableCollection<T> Models { get; private set; }

        private Command _loadModelsCommand;
        public Command LoadModelsCommand
        {
            get
            {
                return _loadModelsCommand ?? (_loadModelsCommand = new Command(ExecuteLoadModelsCommand));
            }
        }

        protected virtual async void ExecuteLoadModelsCommand()
        {
            using (var service = (IRepository<T>)GetDependency.Invoke(null, new object[] { DependencyFetchTarget.GlobalInstance }))
            {
                var objects = await service.GetAllAsync();

                foreach (var obj in objects)
                    Models.Add(obj);
            }
            OnPropertyChanged("Models");
        }
    }

    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public BaseViewModel()
        {

        }

        private string _title = string.Empty;
        public const string TitlePropertyName = "Title";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value, TitlePropertyName); }
        }

        private string _subtitle = string.Empty;
        public const string SubtitlePropertyName = "Subtitle";
        public string Subtitle
        {
            get { return _subtitle; }
            set { SetProperty(ref _subtitle, value, SubtitlePropertyName); }
        }

        private string _icon = null;
        public const string IconPropertyName = "Icon";
        public string Icon
        {
            get { return _icon; }
            set { SetProperty(ref _icon, value, IconPropertyName); }
        }

        protected void SetProperty<U>(ref U backingStore, U value, string propertyName, Action onChanged = null, Action<U> onChanging = null)
        {
            if (EqualityComparer<U>.Default.Equals(backingStore, value))
                return;

            if (onChanging != null)
                onChanging(value);

            OnPropertyChanging(propertyName);

            backingStore = value;

            if (onChanged != null)
                onChanged();

            OnPropertyChanged(propertyName);
        }

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public void OnPropertyChanging(string propertyName)
        {
            if (PropertyChanging == null)
                return;

            PropertyChanging(this, new Xamarin.Forms.PropertyChangingEventArgs(propertyName));
        }

        public event Xamarin.Forms.PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
