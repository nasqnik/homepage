using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthApp.Data;
using AuthApp.DTOs.Enquiry;
using AuthApp.Helpers;
using AuthApp.Interfaces;
using AuthApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthApp.Repository
{
    public class EnquiryRepository: IEnquiryRepository
    {
        private readonly ApplicationDbContext _context;
        public EnquiryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Enquiry>> GetAllAsync(QueryObject query)
        {
            var enquiries = _context.Enquiry.Include(c => c.Comments).AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Status))
            {
                enquiries = enquiries.Where(s => s.Status.Contains(query.Status));
            }
            if (!string.IsNullOrWhiteSpace(query.CustomerName))
            {
                enquiries = enquiries.Where(s => s.CustomerName.Contains(query.CustomerName));
            }
            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("Status", StringComparison.OrdinalIgnoreCase))
                {
                    enquiries = query.IsDescending ? enquiries.OrderByDescending(s => s.Status) : enquiries.OrderBy(s => s.Status);
                }
                else if (query.SortBy.Equals("Date", StringComparison.OrdinalIgnoreCase))
                {
                    enquiries = query.IsDescending ? enquiries.OrderByDescending(s => s.CreatedOn) : enquiries.OrderBy(s => s.CreatedOn);
                }
            }
            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            return await enquiries.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }
        public async Task<Enquiry?> GetByIdAsync(int id)
        {
            return await _context.Enquiry.Include(c => c.Comments).FirstOrDefaultAsync(i => i.Id == id);
        }
        public async Task<Enquiry> CreateAsync(Enquiry enquiryModel)
        {
            await _context.Enquiry.AddAsync(enquiryModel);
            await _context.SaveChangesAsync();
            return enquiryModel;
        }
        public async Task<Enquiry?> UpdateAsync(int id, UpdateEnquiryDto enquiryDto)
        {
            var existingEnquiry = await _context.Enquiry.FirstOrDefaultAsync(x => x.Id == id);
            if (existingEnquiry == null)
                return null;
            existingEnquiry.Email = enquiryDto.Email;
            existingEnquiry.CustomerName = enquiryDto.CustomerName;
            existingEnquiry.Content = enquiryDto.Content;
            existingEnquiry.Status = enquiryDto.Status;
            await _context.SaveChangesAsync();
            return existingEnquiry;
        }
        public async Task<Enquiry?> DeleteAsync(int id)
        {
            var enquiryModel = await _context.Enquiry.FirstOrDefaultAsync(x => x.Id == id);
            if (enquiryModel == null)
                return null;
            _context.Enquiry.Remove(enquiryModel);
            await _context.SaveChangesAsync();
            return enquiryModel;
        }
        public Task<bool> EnquiryExists(int id)
        {
            return _context.Enquiry.AnyAsync(s => s.Id == id);
        }
    }
}