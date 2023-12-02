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



}


