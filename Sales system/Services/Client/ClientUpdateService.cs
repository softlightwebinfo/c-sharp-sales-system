using Sales_system.Interfaces.Repository.Client;
using Sales_system.Interfaces.Services.Client;
using Sales_system.Models.Request.Client;

namespace Sales_system.Services.Client
{
    public class ClientUpdateService : IClientUpdateService
    {
        private readonly IClientRepository _clientRepository;

        public ClientUpdateService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public void Update(ClientUpdateRequest model)
        {
            _clientRepository.Update(model);
        }
    }
}