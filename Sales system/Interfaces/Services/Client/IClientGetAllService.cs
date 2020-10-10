using System.Collections.Generic;

namespace Sales_system.Interfaces.Services.Client
{
    public interface IClientGetAllService
    {
        public List<Models.Client> GetAll();
    }
}