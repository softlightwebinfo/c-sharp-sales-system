using System.Collections.Generic;

namespace Sales_system.Models.Request
{
    public class SaleRequest
    {
        public int IdClient { get; set; }
        public decimal Total { get; set; }
        public List<ConceptRequest> Concepts { get; set; }

        public SaleRequest()
        {
            Concepts = new List<ConceptRequest>();
        }
    }

    public class ConceptRequest
    {
        public int IdProduct { get; set; }
        public decimal PriceUnit { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
    }
}