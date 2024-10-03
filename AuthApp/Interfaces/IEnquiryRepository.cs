using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthApp.Models;
using AuthApp.DTOs.Enquiry;
using AuthApp.Helpers;

namespace AuthApp.Interfaces
{
    public interface IEnquiryRepository
    {
       Task<List<Enquiry>> GetAllAsync(QueryObject query); 
       Task<Enquiry?> GetByIdAsync(int id);
       Task<Enquiry> CreateAsync(Enquiry enquiryModel);
       Task<Enquiry?> UpdateAsync(int id, UpdateEnquiryDto enquiryDto);
       Task<Enquiry?> DeleteAsync(int id);
       Task<bool> EnquiryExists(int id);
    }
}