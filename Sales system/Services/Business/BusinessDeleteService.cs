using Sales_system.Interfaces.Repository.Business;
using Sales_system.Interfaces.Services.Business;

namespace Sales_system.Services.Business
{
    public class BusinessDeleteService : IBusinessDeleteService
    {
        private readonly IBusinessRepository _businessRepository;

        public BusinessDeleteService(IBusinessRepository businessRepository)
        {
            _businessRepository = businessRepository;
        }

        public void Delete(long id)
        {
            _businessRepository.Remove(id);
        }
    }
}