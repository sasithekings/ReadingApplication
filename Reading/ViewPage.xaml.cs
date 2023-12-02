
namespace Reading
{
    public partial class ViewPage : ContentPage
    {
        public ViewPage()
        {
            InitializeComponent();
            BindingContext = new ViewPageViewModel();
        }

        [Obsolete]
        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is DataEntry tappedItem)
            {

                Navigation.PushAsync(new ContentPage
                {
                    Content = new StackLayout
                    {
                        Children =
                        {
                            new Label
                            {
                                Text = "Title: " + tappedItem.title,
                                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                                FontAttributes = FontAttributes.Bold,
                                TextColor = Color.FromHex("#3498db"),
                                 HorizontalOptions = LayoutOptions.Center,
                                Margin = new Thickness(0, 10, 0, 0)
                            },
                            new Label
                            {
                                Text = "Content: " + tappedItem.content,
                                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                                TextColor = Color.FromHex("#3498db"),
                                 HorizontalOptions = LayoutOptions.Center,
                                Margin = new Thickness(0, 5, 0, 0)
                            }
                        },
                        BackgroundColor = Color.FromHex("#ecf0f1"),
                        Padding = new Thickness(20),
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        VerticalOptions = LayoutOptions.CenterAndExpand
                    }
                });
            }
        }
    }


}
