using Sales_system.Interfaces.Repository.Product;
using Sales_system.Interfaces.Services.Product;
using Sales_system.Models.Request.Product;

namespace Sales_system.Services.Product
{
    public class ProductPublishService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductPublishService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void PublishNew(ProductCreateRequest model)
        {
            _productRepository.Create(model);
        }
    }
}