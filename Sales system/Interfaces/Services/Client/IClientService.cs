using Sales_system.Models.Request.Client;

namespace Sales_system.Interfaces.Services.Client
{
    public interface IClientService
    {
        public void PublishNew(ClientCreateRequest model);
    }
}