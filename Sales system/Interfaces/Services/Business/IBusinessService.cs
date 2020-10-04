using Sales_system.Models.Request.Business;

namespace Sales_system.Interfaces
{
    public interface IBusinessService
    {
        public void PublishNew(BusinessCreateRequest model);
    }
}