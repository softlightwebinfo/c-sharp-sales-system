using System;
using System.Collections.Generic;
using System.Linq;
using Sales_system.Interfaces.Repository.Suppliers;
using Sales_system.Models;
using Sales_system.Models.Request.Suppliers;

namespace Sales_system.Repository.Suppliers
{
    public class SuppliersRepository : ISuppliersRepository
    {
        public Supplier Get(long id)
        {
            using var db = new salesSystemContext();
            return db.Suppliers.FirstOrDefault(e => e.Id == id)!;
        }

        public List<Supplier> GetAll()
        {
            using var db = new salesSystemContext();
            return db.Suppliers.Where(supplier => !supplier.DeletedAt.HasValue).ToList();
        }

        public void Remove(long id)
        {
            using var db = new salesSystemContext();
            var business = db.Suppliers.Find(id);
            business.DeletedAt = DateTime.Now;
            db.Entry(business).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }

        public void Update(SuppliersUpdateRequest model)
        {
            using var db = new salesSystemContext();
            var supplier = db.Suppliers.Find(model.Id);
            supplier.Email = model.Email;
            supplier.SupplierName = model.SupplierName;
            supplier.Phone = model.Phone;
            supplier.UpdatedAt = DateTime.Now;
            db.Entry(supplier).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }

        public void Create(SuppliersCreateRequest model)
        {
            using var db = new salesSystemContext();
            var supplier = new Supplier()
            {
                Email = model.Email,
                Phone = model.Phone,
                SupplierName = model.SupplierName,
                FkUserId = model.FkUserId
            };
            db.Suppliers.Add(supplier);
            db.SaveChanges();
        }
    }
}