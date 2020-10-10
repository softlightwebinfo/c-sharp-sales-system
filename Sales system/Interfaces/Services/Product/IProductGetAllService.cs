using System.Collections.Generic;

namespace Sales_system.Interfaces.Services.Product
{
    public interface IProductGetAllService
    {
        public List<Models.Product> GetAll();
    }
}