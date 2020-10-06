using Sales_system.Interfaces.Repository.Business;
using Sales_system.Interfaces.Services.Business;
using Sales_system.Models.Request.Business;

namespace Sales_system.Services.Business
{
    public class BusinessPublishService : IBusinessService
    {
        private readonly IBusinessRepository _businessRepository;

        public BusinessPublishService(IBusinessRepository businessRepository)
        {
            _businessRepository = businessRepository;
        }

        public void PublishNew(BusinessCreateRequest model)
        {
            _businessRepository.Create(model);
        }
    }
}