using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AuthApp.DTOs.Enquiry
{
    public class UpdateEnquiryDto
    {
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        [MaxLength(30, ErrorMessage = "Customer's name cannot be over 30 characters")]
        public string CustomerName { get; set; } = string.Empty;
        
        [Required]
        [MinLength(5, ErrorMessage = "Content must be 5 characters")]
        [MaxLength(280, ErrorMessage = "Content cannot be over 280 characters")]
        public string Content { get; set; } = string.Empty;
        [Required]
        public string Status { get; set; } = string.Empty;
    }
}