using System.Collections.Generic;
using Sales_system.Interfaces.Repository.Product;
using Sales_system.Interfaces.Services.Product;

namespace Sales_system.Services.Product
{
    public class ProductGetAllService : IProductGetAllService
    {
        private readonly IProductRepository _productRepository;

        public ProductGetAllService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<Models.Product> GetAll()
        {
            return _productRepository.GetAll();
        }
    }
}