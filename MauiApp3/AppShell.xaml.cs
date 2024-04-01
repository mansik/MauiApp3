namespace MauiApp3;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // register DetailPage with the routing system of .MAUIShell
        Routing.RegisterRoute(nameof(DetailPage), typeof(DetailPage));
    }
}