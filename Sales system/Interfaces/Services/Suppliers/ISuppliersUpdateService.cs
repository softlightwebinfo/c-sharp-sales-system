using Sales_system.Models.Request.Suppliers;

namespace Sales_system.Interfaces.Services.Suppliers
{
    public interface ISuppliersUpdateService
    {
        public void Update(SuppliersUpdateRequest model);
    }
}