using System;
using System.Collections.Generic;
using System.Linq;
using Sales_system.Interfaces.Repository.Product;
using Sales_system.Models;
using Sales_system.Models.Request.Product;

namespace Sales_system.Repository.Product
{
    public class ProductRepository : IProductRepository
    {
        public Models.Product Get(long id)
        {
            using var db = new salesSystemContext();
            return db.Products.FirstOrDefault(e => e.Id == id)!;
        }
        
        public List<Models.Product> GetAll()
        {
            using var db = new salesSystemContext();
            return db.Products.Where(product => !product.DeletedAt.HasValue).ToList();
        }

        public void Remove(long id)
        {
            using var db = new salesSystemContext();
            var business = db.Products.Find(id);
            business.DeletedAt = DateTime.Now;
            db.Entry(business).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }

        public void Update(ProductUpdateRequest model)
        {
            using var db = new salesSystemContext();
            var product = db.Products.Find(model.Id);
            // product.UpdatedAt = DateTime.Now;
            product.Amount = model.Amount;
            product.Description = model.Description;
            product.ProductName = model.ProductName;
            product.UnitPrice = model.UnitPrice;
            product.UpdatedAt = DateTime.Now;
            db.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }

        public void Create(ProductCreateRequest model)
        {
            using var db = new salesSystemContext();
            var product = new Models.Product()
            {
                Amount = model.Amount,
                Description = model.Description,
                ProductName = model.ProductName,
                UnitPrice = model.UnitPrice
            };
            db.Products.Add(product);
            db.SaveChanges();
        }
    }
}