using Sales_system.Models.Request.Business;

namespace Sales_system.Interfaces.Services.Business
{
    public interface IBusinessUpdateService
    {
        public void Update(BusinessUpdateRequest model);
    }
}