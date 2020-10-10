using Sales_system.Models.Request.Product;

namespace Sales_system.Interfaces.Services.Product
{
    public interface IProductService
    {
        public void PublishNew(ProductCreateRequest model);
    }
}