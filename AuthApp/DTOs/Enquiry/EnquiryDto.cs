using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthApp.DTOs.Comment;

namespace AuthApp.DTOs.Enquiry
{
    public class EnquiryDto
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now; 
        public string Email { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public List<CommentDto> Comments { get; set; } 
    }
}