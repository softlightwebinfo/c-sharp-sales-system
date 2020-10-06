using Sales_system.Models.Request.Suppliers;

namespace Sales_system.Interfaces.Services.Suppliers
{
    public interface ISuppliersService
    {
        public void PublishNew(SuppliersCreateRequest model);
    }
}