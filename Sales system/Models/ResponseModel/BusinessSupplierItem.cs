using System;

namespace Sales_system.Models.ResponseModel
{
    public class BusinessSupplierItem
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}