using PublicApiApplication.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.Dynamic;
using static PublicApiApplication.Models.publicapi;

namespace PublicApiApplication.Services
{
    class PublicapiDataStoreAPI : IPublicapiDataStore<Publicapi>
    {
        private static string API => "https://api.publicapis.org/entries";

        public async Task<IEnumerable<Publicapi>> GetPublicapiAsync(int count)
        {
            var service = DependencyService.Get<IWebClientService>();
            var json = await service.GetAsync($"{API}?results={count}");

            var publicapi = PublicapiBuilder(json);

            return publicapi;
        }
        private List<publicapi> PublicapiBuilder(string json)
        {

            var response = JsonConvert.DeserializeObject<dynamic>(json);
            var users = response.results;

            var publicapi = new List<Publicapi>();

            foreach (var user in users)
            {
                var firstName = user.name.first.ToString();
                var lastName = user.name.last.ToString();
                var api = $"{firstName} {lastName}";
                var description = user.email.ToString();
                var link = user.picture.medium.ToString();

                publicapi.Add(new Publicapi(api, description, link));

            }

            return publicapi;
        }

        public static class UserBuilder
        {

        }
    }
}
