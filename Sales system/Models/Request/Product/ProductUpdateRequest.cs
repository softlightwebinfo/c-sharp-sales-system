namespace Sales_system.Models.Request.Product
{
    public class ProductUpdateRequest : ProductCreateRequest
    {
        public long Id { get; set; }
    }
}