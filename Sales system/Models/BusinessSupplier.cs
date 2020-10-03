using System;
using System.Collections.Generic;

#nullable disable

namespace Sales_system.Models
{
    public partial class BusinessSupplier
    {
        public long FkBusinessId { get; set; }
        public long FkSupplierId { get; set; }

        public virtual Business FkBusiness { get; set; }
        public virtual Supplier FkSupplier { get; set; }
    }
}
