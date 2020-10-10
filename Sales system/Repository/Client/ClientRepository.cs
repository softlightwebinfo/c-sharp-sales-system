using System;
using System.Collections.Generic;
using System.Linq;
using Sales_system.Interfaces.Repository.Client;
using Sales_system.Models;
using Sales_system.Models.Request.Client;

namespace Sales_system.Repository.Client
{
    public class ClientRepository : IClientRepository
    {
        public Models.Client Get(long id)
        {
            using var db = new salesSystemContext();
            return db.Clients.FirstOrDefault(e => e.Id == id)!;
        }
        
        public List<Models.Client> GetAll()
        {
            using var db = new salesSystemContext();
            return db.Clients.Where(client => !client.DeletedAt.HasValue).ToList();
        }

        public void Remove(long id)
        {
            using var db = new salesSystemContext();
            var client = db.Clients.Find(id);
            client.DeletedAt = DateTime.Now;
            db.Entry(client).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }

        public void Update(ClientUpdateRequest model)
        {
            using var db = new salesSystemContext();
            var client = db.Clients.Find(model.Id);
            // product.UpdatedAt = DateTime.Now;
            client.ClientName = model.Name;
            client.UpdatedAt = DateTime.Now;
            db.Entry(client).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }

        public void Create(ClientCreateRequest model)
        {
            using var db = new salesSystemContext();
            var client = new Models.Client()
            {
                ClientName = model.Name
            };
            db.Clients.Add(client);
            db.SaveChanges();
        }
    }
}