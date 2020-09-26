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

        public int Id { get; set; }
        public string ClientName { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
