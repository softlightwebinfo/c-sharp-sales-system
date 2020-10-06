using System.Collections.Generic;
using Sales_system.Models;

namespace Sales_system.Interfaces.Services.Suppliers
{
    public interface ISuppliersGetAllService
    {
        public List<Supplier> GetAll();
    }
}