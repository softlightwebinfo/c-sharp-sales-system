using Sales_system.Interfaces.Repository.Client;
using Sales_system.Interfaces.Services.Client;

namespace Sales_system.Services.Client
{
    public class ClientGetService : IClientGetService
    {
        private readonly IClientRepository _clientRepository;

        public ClientGetService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public Models.Client Get(long id)
        {
            return _clientRepository.Get(id);
        }
    }
}