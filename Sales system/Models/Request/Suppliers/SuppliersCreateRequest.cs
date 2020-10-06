namespace Sales_system.Models.Request.Suppliers
{
    public class SuppliersCreateRequest
    {
        public string SupplierName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public long FkUserId { get; set; }
    }
}