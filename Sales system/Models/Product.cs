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

        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }

        public virtual ICollection<BusinessProduct> BusinessProducts { get; set; }
        public virtual ICollection<Concept> Concepts { get; set; }
        public virtual ICollection<SuppliersProduct> SuppliersProducts { get; set; }
    }
}
