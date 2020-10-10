using Sales_system.Interfaces.Repository.Client;
using Sales_system.Interfaces.Services.Client;
using Sales_system.Models.Request.Client;

namespace Sales_system.Services.Client
{
    public class ClientPublishService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientPublishService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public void PublishNew(ClientCreateRequest model)
        {
            _clientRepository.Create(model);
        }
    }
}