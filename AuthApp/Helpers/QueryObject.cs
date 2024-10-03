using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthApp.Helpers
{
    public class QueryObject
    {
        public string? Status { get; set; } = null;
        public string? CustomerName { get; set; }
        public DateTime CreatedOn { get; set; }

        public string? SortBy { get; set; } = null;
        public bool IsDescending { get; set; } = false;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}