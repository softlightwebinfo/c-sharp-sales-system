using System.Collections.Generic;
using Sales_system.Models.Request.Product;

namespace Sales_system.Interfaces.Repository.Product
{
    public interface IProductRepository : IWriteable<ProductCreateRequest, ProductUpdateRequest>,
        IReadable<List<Models.Product>, Models.Product, long>,
        IRemovable<long>
    {
    }
}