using System;
using System.Collections.Generic;

#nullable disable

namespace Sales_system.Models
{
    public partial class BusinessProduct
    {
        public long FkBusinessId { get; set; }
        public long FkProductId { get; set; }

        public virtual Business FkBusiness { get; set; }
        public virtual Product FkProduct { get; set; }
    }
}
