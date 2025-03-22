using System.Collections.Generic;
using System.Threading.Tasks;
using ClientTrack.DBL.Models;

namespace ClientTrack.DBL.Repositories
{
    public interface IClientRepository
    {
        IEnumerable<CountryModel> GetCountries();
        //IEnumerable<StatusModel> GetStatuses();
        IEnumerable<ProductModel> GetProducts();

        Task<int> CreateClientAsync(ClientModel client); 
        Task<IEnumerable<ClientModel>> GetAllClientsAsync();
        Task<ClientModel> GetClientAsync(int clientId);
    }
}
