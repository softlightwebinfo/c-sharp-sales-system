using Sales_system.Interfaces.Repository.Suppliers;
using Sales_system.Interfaces.Services.Suppliers;

namespace Sales_system.Services.Suppliers
{
    public class SuppliersDeleteService : ISuppliersDeleteService
    {
        private readonly ISuppliersRepository _suppliersRepository;

        public SuppliersDeleteService(ISuppliersRepository suppliersRepository)
        {
            _suppliersRepository = suppliersRepository;
        }

        public void Delete(long id)
        {
            _suppliersRepository.Remove(id);
        }
    }
}