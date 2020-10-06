using Sales_system.Models;

namespace Sales_system.Interfaces
{
    public interface IReadable<out TGetAll, out TGet, in TGetId>
    {
        TGet Get(TGetId id);
        TGetAll GetAll();
    }
}