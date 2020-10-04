using System;
using System.Collections.Generic;

#nullable disable

namespace Sales_system.Models
{
    public partial class Business
    {
        public Business()
        {
            BusinessProducts = new HashSet<BusinessProduct>();
        }

        public long Id { get; set; }
        public long FkUserId { get; set; }
        public string BusinessName { get; set; }
        public string Address { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual User FkUser { get; set; }
        public virtual BusinessSupplier BusinessSupplier { get; set; }
        public virtual ICollection<BusinessProduct> BusinessProducts { get; set; }
    }
}
