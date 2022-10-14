using PublicApiApplication.Services;
using PublicApiApplication;

namespace PublicApiApplication;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        DependencyService.Register<PublicapiDataStoreAPI>();
        DependencyService.Register<WebClientService>();
        MainPage = new AppShell();
    }
}