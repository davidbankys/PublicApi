using PublicApiApplication.Services;
using PublicApiApplication;
using PublicApiApplication.Services;

namespace Population_App;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        DependencyService.Register<PublicapiDataStore>();
        DependencyService.Register<WebClientService>();
        MainPage = new AppShell();
    }
}