using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiApp3.ViewModel;

// [QueryProperty("Text", "id")] // await Shell.Current.GoToAsync($"{nameof(DetailPage)}?id={s}");
[QueryProperty("Text", "Text")]
public partial class DetailViewModel : ObservableObject
{
    [ObservableProperty]
    string text; // "Text" property  of [QueryProperty("Text", "id")]

    [RelayCommand]
    async Task GoBack()
    {
        await Shell.Current.GoToAsync("..");
    }
}
