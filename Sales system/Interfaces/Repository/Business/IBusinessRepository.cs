using System.Collections.Generic;
using Sales_system.Models.Request.Business;

namespace Sales_system.Interfaces.Repository.Business
{
    public interface IBusinessRepository : IWriteable<BusinessCreateRequest, BusinessUpdateRequest>,
        IReadable<List<Models.Business>, Models.Business, long>,
        IRemovable<long>
    {
    }
}