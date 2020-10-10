using System.ComponentModel.DataAnnotations;

namespace Sales_system.Models.Request.Client
{
    public class ClientUpdateRequest
    {
        [Required] public long Id { get; set; }
        [Required] public string? Name { get; set; }
    }
}