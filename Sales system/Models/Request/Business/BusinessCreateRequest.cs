using System.ComponentModel.DataAnnotations;

namespace Sales_system.Models.Request.Business
{
    public class BusinessCreateRequest
    {
        [Required] public string BusinessName { get; set; }
        [Required] public string Address { get; set; }
        [Required] public int FkUserId { get; set; }
    }
}