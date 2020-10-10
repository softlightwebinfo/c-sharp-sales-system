using System.Collections.Generic;

namespace Sales_system.Models.Response
{
    public class ListPaginationResponse<T>
    {
        public ListPaginationResponse()
        {
            List = new List<T>();
        }

        public int Count { get; set; }
        public int Total { get; set; }
        public List<T> List { get; set; }
    }
}