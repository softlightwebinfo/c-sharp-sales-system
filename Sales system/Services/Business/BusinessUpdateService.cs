using Sales_system.Interfaces.Repository.Business;
using Sales_system.Interfaces.Services.Business;
using Sales_system.Models.Request.Business;

namespace Sales_system.Services.Business
{
    public class BusinessUpdateService : IBusinessUpdateService
    {
        private readonly IBusinessRepository _businessRepository;

        public BusinessUpdateService(IBusinessRepository businessRepository)
        {
            _businessRepository = businessRepository;
        }

        public void Update(BusinessUpdateRequest model)
        {
            _businessRepository.Update(model);
        }
    }
}