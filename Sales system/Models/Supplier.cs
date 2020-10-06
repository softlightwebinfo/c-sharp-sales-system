using System;
using System.Collections.Generic;

#nullable disable

namespace Sales_system.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            BusinessSuppliers = new HashSet<BusinessSupplier>();
            SuppliersProducts = new HashSet<SuppliersProduct>();
        }

        public long Id { get; set; }
        public string SupplierName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public long FkUserId { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual User FkUser { get; set; }
        public virtual ICollection<BusinessSupplier> BusinessSuppliers { get; set; }
        public virtual ICollection<SuppliersProduct> SuppliersProducts { get; set; }
    }
}
