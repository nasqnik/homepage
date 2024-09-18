using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthApp.Models
{
    public class Enquiry
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;

        public Enquiry()
        {

        }
    }
}