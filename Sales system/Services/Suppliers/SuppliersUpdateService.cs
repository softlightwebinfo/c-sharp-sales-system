using Sales_system.Interfaces.Repository.Suppliers;
using Sales_system.Interfaces.Services.Suppliers;
using Sales_system.Models.Request.Suppliers;

namespace Sales_system.Services.Suppliers
{
    public class SuppliersUpdateService : ISuppliersUpdateService
    {
        private readonly ISuppliersRepository _suppliersRepository;

        public SuppliersUpdateService(ISuppliersRepository suppliersRepository)
        {
            _suppliersRepository = suppliersRepository;
        }

        public void Update(SuppliersUpdateRequest model)
        {
            _suppliersRepository.Update(model);
        }
    }
}