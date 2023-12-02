using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Reading
{
    public class MainViewModel : BindableObject
    {
        public ObservableCollection<DataEntry> DataItems { get; set; } = new ObservableCollection<DataEntry>();

        public ICommand ViewPageCommand => new Command(ExecuteViewPageCommand);
        public ICommand AddPageCommand => new Command(ExecuteAddPageCommand);

        private void ExecuteViewPageCommand()
        {
            Application.Current.MainPage.Navigation.PushAsync(new ViewPage());
        }

        private void ExecuteAddPageCommand()
        {
            Application.Current.MainPage.Navigation.PushAsync(new AddPage());
        }


    }

    public class ViewPageViewModel : BindableObject
    {
        public ObservableCollection<DataEntry> DataEntrys { get; set; } = new ObservableCollection<DataEntry>();
        public ICommand ItemSelectedCommand { get; }
        public ViewPageViewModel()
        {
            LoadData();
        }

        private void LoadData()
        {
            var service = new ReadingDataBase();
            DataEntrys = service.GetDataItems();
        }
    }




    public class AddPageViewModel : BindableObject
    {
        private string _title;
        private string _content;

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        public string Content
        {
            get { return _content; }
            set
            {
                _content = value;
                OnPropertyChanged(nameof(Content));
            }
        }

        public ICommand SubmitCommand => new Command(ExecuteSubmitCommand);

        private void ExecuteSubmitCommand()
        {
            var newItem = new DataEntry { title = Title, content = Content };
            var service = new ReadingDataBase();
            service.InsertDataItem(newItem);

            Application.Current.MainPage.Navigation.PopAsync();
        }
    }

}


