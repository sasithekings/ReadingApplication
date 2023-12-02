
namespace Reading
{
    public partial class ViewPage : ContentPage
    {
        public ViewPage()
        {
            InitializeComponent();
            BindingContext = new ViewPageViewModel();
        }
    }


}
