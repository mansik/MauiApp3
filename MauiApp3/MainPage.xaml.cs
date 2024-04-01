using MauiApp3.ViewModel;

namespace MauiApp3;

public partial class MainPage : ContentPage
{
    public MainPage(MainViewModel vm)
    {
        InitializeComponent();

        // set the BindingContext for ViewModel in DetailPage(data binding)
        BindingContext = vm;
    }
}

