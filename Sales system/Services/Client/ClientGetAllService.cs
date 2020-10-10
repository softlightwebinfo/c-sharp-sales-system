using System.Collections.Generic;
using Sales_system.Interfaces.Repository.Client;
using Sales_system.Interfaces.Services.Client;

namespace Sales_system.Services.Client
{
    public class ClientGetAllService : IClientGetAllService
    {
        private readonly IClientRepository _clientRepository;

        public ClientGetAllService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public List<Models.Client> GetAll()
        {
            return _clientRepository.GetAll();
        }
    }
}