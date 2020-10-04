using System.ComponentModel.DataAnnotations;

namespace Sales_system.Models.Request.Business
{
    public class BusinessUpdateRequest
    {
        [Required] public long Id { get; set; }
        [Required] public string BusinessName { get; set; }
        [Required] public string Address { get; set; }
    }
}