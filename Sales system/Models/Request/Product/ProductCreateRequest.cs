using System;
using System.ComponentModel.DataAnnotations;

namespace Sales_system.Models.Request.Product
{
    public class ProductCreateRequest
    {
        [Required] public string? ProductName { get; set; }
        [Required] public decimal UnitPrice { get; set; }
        [Required] public decimal Amount { get; set; }
        [Required] public string? Description { get; set; }
    }
}