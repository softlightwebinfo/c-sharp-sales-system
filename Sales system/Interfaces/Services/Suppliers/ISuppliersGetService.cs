using Sales_system.Models;

namespace Sales_system.Interfaces.Services.Suppliers
{
    public interface ISuppliersGetService
    {
        public Supplier Get(long id);
    }
}