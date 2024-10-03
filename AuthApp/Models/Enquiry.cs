using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthApp.Models
{
    public class Enquiry
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now.ToUniversalTime();
        public string Email { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public Enquiry()
        {

        }
    }
}