using System.Collections.Generic;
using Sales_system.Interfaces.Repository.Suppliers;
using Sales_system.Interfaces.Services.Suppliers;
using Sales_system.Models;

namespace Sales_system.Services.Suppliers
{
    public class SuppliersGetAllService : ISuppliersGetAllService
    {
        private readonly ISuppliersRepository _suppliersRepository;

        public SuppliersGetAllService(ISuppliersRepository suppliersRepository)
        {
            _suppliersRepository = suppliersRepository;
        }

        public List<Supplier> GetAll()
        {
            return _suppliersRepository.GetAll();
        }
    }
}