using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiApp3.ViewModel;

// [QueryProperty("Text", "id")] // await Shell.Current.GoToAsync($"{nameof(DetailPage)}?id={s}");
// Text 속성이 id 쿼리 매개 변수에 전달된 데이터를 수신하도록 지정
// https://learn.microsoft.com/ko-kr/dotnet/maui/fundamentals/shell/navigation?view=net-maui-8.0

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
