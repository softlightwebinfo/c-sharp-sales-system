using Sales_system.Models.Request.Client;

namespace Sales_system.Interfaces.Services.Client
{
    public interface IClientUpdateService
    {
        public void Update(ClientUpdateRequest model);
    }
}