using MauiApp3.ViewModel;

namespace MauiApp3;

public partial class DetailPage : ContentPage
{
    public DetailPage(DetailViewModel vm)
    {
        InitializeComponent();

        // set the BindingContext for ViewModel in DetailPage(data binding)
        BindingContext = vm;
    }
}