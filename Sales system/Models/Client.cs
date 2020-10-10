using System;
using System.Collections.Generic;

#nullable disable

namespace Sales_system.Models
{
    public partial class Client
    {
        public Client()
        {
            Sales = new HashSet<Sale>();
        }

        public long Id { get; set; }
        public string ClientName { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
