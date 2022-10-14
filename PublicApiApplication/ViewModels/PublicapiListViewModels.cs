using PublicApiApplication.Models;
using PublicApiApplication.Services;
using MvvmHelpers;
using MvvmHelpers.Commands;

internal class PublicapiListViewModel
{
    public IPublicapiDataStore<Publicapi> DataStore => DependencyService.Get<IPublicapiDataStore<Publicapi>>();
    public ObservableRangeCollection<Publicapi> Publicapi { get; set; }
    public AsyncCommand PageAppearingCommand { get; }

    public PublicapiListViewModel()
    {
        Publicapi = new ObservableRangeCollection<Publicapi>();
        PageAppearingCommand = new AsyncCommand(PageAppearing);
    }

    public async Task Refresh()
    {
        var publicapi = await DataStore.GetPublicapisAsync(20);

        Publicapi.AddRange(publicapi);
    }

    async Task PageAppearing()
    {
        await Refresh();
    }
}
