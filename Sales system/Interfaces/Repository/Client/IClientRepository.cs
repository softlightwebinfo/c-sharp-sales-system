using System.Collections.Generic;
using Sales_system.Models.Request.Client;

namespace Sales_system.Interfaces.Repository.Client
{
    public interface IClientRepository : IWriteable<ClientCreateRequest, ClientUpdateRequest>,
        IReadable<List<Models.Client>, Models.Client, long>,
        IRemovable<long>
    {
    }
}