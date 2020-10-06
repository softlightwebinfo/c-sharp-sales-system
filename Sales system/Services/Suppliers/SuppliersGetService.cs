using Sales_system.Interfaces.Repository.Suppliers;
using Sales_system.Interfaces.Services.Suppliers;
using Sales_system.Models;

namespace Sales_system.Services.Suppliers
{
    public class SuppliersGetService : ISuppliersGetService
    {
        private readonly ISuppliersRepository _suppliersRepository;

        public SuppliersGetService(ISuppliersRepository suppliersRepository)
        {
            _suppliersRepository = suppliersRepository;
        }

        public Supplier Get(long id)
        {
            return _suppliersRepository.Get(id);
        }
    }
}