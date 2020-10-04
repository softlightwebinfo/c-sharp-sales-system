using Sales_system.Interfaces.Repository.Business;
using Sales_system.Models;
using Sales_system.Models.Request.Business;

namespace Sales_system.Repository.Business
{
    public class BusinessRepository : IBusinessRepository
    {
        public void Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public void GetAll()
        {
            throw new System.NotImplementedException();
        }

        public void Remove(long id)
        {
            using var db = new salesSystemContext();
            var business = db.Businesses.Find(id);
            db.Entry(business).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }

        public void Update(BusinessUpdateRequest model)
        {
            using var db = new salesSystemContext();
            var business = db.Businesses.Find(model.Id);
            business.Address = model.Address;
            business.BusinessName = model.BusinessName;
            db.Entry(business).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }

        public void Create(BusinessCreateRequest model)
        {
            using var db = new salesSystemContext();
            var business = new Models.Business
            {
                Address = model.Address,
                BusinessName = model.BusinessName,
                FkUserId = model.FkUserId
            };
            db.Businesses.Add(business);
            db.SaveChanges();
        }
    }
}