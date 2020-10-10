using Sales_system.Interfaces.Repository.Client;
using Sales_system.Interfaces.Services.Client;

namespace Sales_system.Services.Client
{
    public class ClientDeleteService : IClientDeleteService
    {
        private readonly IClientRepository _clientRepository;

        public ClientDeleteService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }


        public void Delete(long id)
        {
            _clientRepository.Remove(id);
        }
    }
}