using Sales_system.Models.Response;

namespace Sales_system.Interfaces.Services.Business
{
    public interface IBusinessSuppliersService
    {
        public BusinessSuppliersResponse GetAll(long id);
    }
}