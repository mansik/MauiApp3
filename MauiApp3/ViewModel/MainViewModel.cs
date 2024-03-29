using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace MauiApp3.ViewModel;
public partial class MainViewModel : ObservableObject
{
    public MainViewModel()
    {
        Items = new ObservableCollection<string>();
    }

    [ObservableProperty]
    ObservableCollection<string> items;

    [ObservableProperty]
    string? text;

    [RelayCommand]
    void Add()
    {
        if (string.IsNullOrWhiteSpace(Text))
            return;

        Items.Add(Text);

        // add our item
        Text = string.Empty;
    }

    [RelayCommand]
    void Delete(string s)
    {
        if (Items.Contains(s))
        {
            Items.Remove(s);
        }
    }

    [RelayCommand]
    async Task Tap(string s)
    {
        // do not send informations
        // await Shell.Current.GoToAsync(nameof(DetailPage));

        // [there's two ways to pass DetailPage information]
        //  1. query property: await Shell.Current.GoToAsync($"{nameof(DetailPage)}?Text={s}");
        //  2. URI
        // to send simple data type like strings and integers across
        await Shell.Current.GoToAsync($"{nameof(DetailPage)}?Text={s}");

        // to send a complex data type, like a person or a car or some other data object
        // await Shell.Current.GoToAsync($"{nameof(DetailPage)}?Text={s}",
        //        new Dictionary<string, object>
        //        {
        //            {nameof(DetailPage), new object()},
        //        });
    }
}
