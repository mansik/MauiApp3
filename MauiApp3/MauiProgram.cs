using MauiApp3.ViewModel;
using Microsoft.Extensions.Logging;

namespace MauiApp3;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif
        // [Dependency injection](https://learn.microsoft.com/en-us/dotnet/maui/fundamentals/dependency-injection?view=net-maui-8.0&source=docs)
        // register DetailPage and DetailViewModel in MAUI program(Dependency injection)
        // AddSingleton<T>: Creates a single instance of the object which will remain for the lifetime of the app.
        // AddTransient<T>	Creates a new instance of the object when requested during resolution.

        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<MainViewModel>();

        builder.Services.AddTransient<DetailPage>();
        builder.Services.AddTransient<DetailViewModel>();

        return builder.Build();
    }
}
