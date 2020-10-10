using Sales_system.Models.Request.Product;

namespace Sales_system.Interfaces.Services.Product
{
    public interface IProductUpdateService
    {
        public void Update(ProductUpdateRequest model);
    }
}