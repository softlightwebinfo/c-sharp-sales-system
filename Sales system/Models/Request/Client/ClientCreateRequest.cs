using System.ComponentModel.DataAnnotations;

namespace Sales_system.Models.Request.Client
{
    public class ClientCreateRequest
    {
        [Required] public string? Name { get; set; }
    }
}