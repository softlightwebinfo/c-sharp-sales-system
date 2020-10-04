namespace Sales_system.Interfaces
{
    public interface IRemovable<in TRemoveId>
    {
        void Remove(TRemoveId id);
    }
}