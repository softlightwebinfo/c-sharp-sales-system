using System;
using System.Collections.Generic;

#nullable disable

namespace Sales_system.Models
{
    public partial class Sale
    {
        public Sale()
        {
            Concepts = new HashSet<Concept>();
        }

        public long Id { get; set; }
        public decimal Total { get; set; }
        public DateTime CreatedAt { get; set; }
        public long FkClientId { get; set; }

        public virtual Client FkClient { get; set; }
        public virtual ICollection<Concept> Concepts { get; set; }
    }
}
