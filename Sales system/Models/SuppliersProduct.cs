using System;
using System.Collections.Generic;

#nullable disable

namespace Sales_system.Models
{
    public partial class SuppliersProduct
    {
        public long FkSupplierId { get; set; }
        public long FkProductId { get; set; }

        public virtual Product FkProduct { get; set; }
        public virtual Supplier FkSupplier { get; set; }
    }
}
