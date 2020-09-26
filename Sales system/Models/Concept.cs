using System;
using System.Collections.Generic;

#nullable disable

namespace Sales_system.Models
{
    public partial class Concept
    {
        public long Id { get; set; }
        public long FkSaleId { get; set; }
        public decimal PriceUnit { get; set; }
        public decimal? Amount { get; set; }
        public int FkProductId { get; set; }
        public decimal Total { get; set; }

        public virtual Product FkProduct { get; set; }
        public virtual Sale FkSale { get; set; }
    }
}
