using PublicApiApplication.Models;
using PublicApiApplication.Services;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace PublicApiApplication.Services
{
    interface IPublicapiDataStore<T>
    {
        Task<IEnumerable<Publicapi>> GetPublicapisAsync(int count);
    }
}