using System;
using System.Collections.Generic;

#nullable disable

namespace Sales_system.Models
{
    public partial class User
    {
        public User()
        {
            Businesses = new HashSet<Business>();
            Suppliers = new HashSet<Supplier>();
        }

        public long Id { get; set; }
        public string Email { get; set; }
        public string UserPassword { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string Surnames { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<Business> Businesses { get; set; }
        public virtual ICollection<Supplier> Suppliers { get; set; }
    }
}
