using System.Collections.Generic;
using System.Threading.Tasks;
using ClientTrack.DBL.Models;
using ClientTrack.DBL.Repositories;

namespace ClientTrack.BL
{
    public class ClientBL 
    {
        private readonly IClientRepository _clientRepository;

        public ClientBL(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<IEnumerable<ClientModel>> GetClientsAsync()
        {
            return await _clientRepository.GetAllClientsAsync();
        }

        public async Task<ClientModel> GetClientAsync(int clientId)
        {
            return await _clientRepository.GetClientAsync(clientId);
        }

        //public IEnumerable<StatusModel> GetStatuses()
        //{
        //    return _clientRepository.GetStatuses();
        //}

        public IEnumerable<ProductModel> GetProducts()
        {
            return _clientRepository.GetProducts();
        }

        public IEnumerable<CountryModel> GetCountries()
        {
            return _clientRepository.GetCountries();
        }

        public async Task<int> CreateClientAsync(ClientModel client)
        {
            return await _clientRepository.CreateClientAsync(client);
        }

    }
}
