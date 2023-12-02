namespace Reading
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var temp = new ReadingDataBase();
            BindingContext = new MainViewModel();
        }
    }

}
