using System.Collections.Generic;
using Sales_system.Models.Request.Suppliers;

namespace Sales_system.Interfaces.Repository.Suppliers
{
    public interface ISuppliersRepository : IWriteable<SuppliersCreateRequest, SuppliersUpdateRequest>,
        IReadable<List<Models.Supplier>, Models.Supplier, long>,
        IRemovable<long>
    {
    }
}