namespace Sales_system.Interfaces
{
    public interface IWriteable<in TCreate, in TUpdate>
    {
        void Update(TUpdate model);
        void Create(TCreate model);
    }
}