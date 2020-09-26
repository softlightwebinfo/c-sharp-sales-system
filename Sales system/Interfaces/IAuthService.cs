using Sales_system.Models.Request;
using Sales_system.Models.Response;

namespace Sales_system.Interfaces
{
    public interface IAuthService
    {
        UserResponse Auth(AuthRequest model);
    }
}