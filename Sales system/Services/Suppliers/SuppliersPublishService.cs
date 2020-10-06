using Sales_system.Interfaces.Repository.Suppliers;
using Sales_system.Interfaces.Services.Suppliers;
using Sales_system.Models.Request.Suppliers;

namespace Sales_system.Services.Suppliers
{
    public class SuppliersPublishService : ISuppliersService
    {
        private readonly ISuppliersRepository _suppliersRepository;

        public SuppliersPublishService(ISuppliersRepository suppliersRepository)
        {
            _suppliersRepository = suppliersRepository;
        }

        public void PublishNew(SuppliersCreateRequest model)
        {
            _suppliersRepository.Create(model);
        }
    }
}