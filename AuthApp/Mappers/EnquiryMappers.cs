using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthApp.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using AuthApp.DTOs.Enquiry;

namespace AuthApp.Mappers
{
    public static class EnquiryMappers
    {
        public static EnquiryDto ToEnquiryDto(this Enquiry enquiryModel)
        {
            return new EnquiryDto
            {
                Id = enquiryModel.Id,
                CreatedOn = enquiryModel.CreatedOn,
                Email = enquiryModel.Email,
                CustomerName = enquiryModel.CustomerName,
                Content = enquiryModel.Content,
                Status = enquiryModel.Status,
                Comments = enquiryModel.Comments.Select(c => c.ToCommentDto()).ToList()
            };
        }

        public static Enquiry ToEnquiryFromCreateDto(this CreateEnquiryDto enquiryDto)
        {
            return new Enquiry
            {
                Email = enquiryDto.Email,
                CustomerName = enquiryDto.CustomerName,
                Content = enquiryDto.Content,
                Status = enquiryDto.Status
            };
        }
    }
}