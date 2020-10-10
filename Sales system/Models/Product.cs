using System;
using System.Collections.Generic;

#nullable disable

namespace Sales_system.Models
{
    public partial class Product
    {
        public Product()
        {
            BusinessProducts = new HashSet<BusinessProduct>();
            Concepts = new HashSet<Concept>();
            SuppliersProducts = new HashSet<SuppliersProduct>();
        }

        public long Id { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<BusinessProduct> BusinessProducts { get; set; }
        public virtual ICollection<Concept> Concepts { get; set; }
        public virtual ICollection<SuppliersProduct> SuppliersProducts { get; set; }
    }
}
