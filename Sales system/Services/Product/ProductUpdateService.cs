using Sales_system.Interfaces.Repository.Product;
using Sales_system.Interfaces.Services.Product;
using Sales_system.Models.Request.Product;

namespace Sales_system.Services.Product
{
    public class ProductUpdateService : IProductUpdateService
    {
        private readonly IProductRepository _productRepository;

        public ProductUpdateService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Update(ProductUpdateRequest model)
        {
            _productRepository.Update(model);
        }
    }
}