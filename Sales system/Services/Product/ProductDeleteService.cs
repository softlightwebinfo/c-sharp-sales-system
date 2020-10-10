using Sales_system.Interfaces.Repository.Product;
using Sales_system.Interfaces.Services.Product;

namespace Sales_system.Services.Product
{
    public class ProductDeleteService : IProductDeleteService
    {
        private readonly IProductRepository _productRepository;

        public ProductDeleteService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        public void Delete(long id)
        {
            _productRepository.Remove(id);
        }
    }
}