using Sales_system.Interfaces.Repository.Product;
using Sales_system.Interfaces.Services.Product;

namespace Sales_system.Services.Product
{
    public class ProductGetService : IProductGetService
    {
        private readonly IProductRepository _productRepository;

        public ProductGetService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Models.Product Get(long id)
        {
            return _productRepository.Get(id);
        }
    }
}