using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AuthApp.Data;
using AuthApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using AuthApp.Interfaces;
using AuthApp.DTOs.Enquiry;
using AuthApp.Helpers;
using AuthApp.Mappers;
using Microsoft.Identity.Client;

namespace AuthApp.Controllers
{
    [Route("AuthApp/enquiry")]
    [ApiController]
    public class EnquiryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IEnquiryRepository _enquiryRepo;

        public EnquiryController(ApplicationDbContext context, IEnquiryRepository enquiryRepo)
        {
            _enquiryRepo = enquiryRepo;
            _context = context;
        }

        // GET: Enquiry
        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var enquiries = await _enquiryRepo.GetAllAsync(query);
            var enquiryDto = enquiries.Select(s => s.ToEnquiryDto());
            return Ok(enquiryDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
              return BadRequest(ModelState);
            var enquiry = await _enquiryRepo.GetByIdAsync(id);
            if (enquiry == null)
            {
                return NotFound();
            }
            return Ok(enquiry.ToEnquiryDto());
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEnquiryDto enquiryDto)
        {
            if (!ModelState.IsValid)
              return BadRequest(ModelState);
            var enquiryModel = enquiryDto.ToEnquiryFromCreateDto();
            await _enquiryRepo.CreateAsync(enquiryModel);
            return CreatedAtAction(nameof(GetById), new { id = enquiryModel.Id }, enquiryModel.ToEnquiryDto());
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateEnquiryDto updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var enquiryModel = await _enquiryRepo.UpdateAsync(id, updateDto);
            if (enquiryModel == null)
                return NotFound();
            return Ok(enquiryModel.ToEnquiryDto());
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var enquiryModel = await _enquiryRepo.DeleteAsync(id);
            if (enquiryModel == null)
                return NotFound();
            return NoContent();
        }

        // public async Task<IActionResult> Index()
        // {
        //     return View(await _context.Enquiry.ToListAsync());
        // }

        // // GET: Enquiry/Details/5
        // [Authorize]
        // public async Task<IActionResult> Details(int? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     var enquiry = await _context.Enquiry
        //         .FirstOrDefaultAsync(m => m.Id == id);
        //     if (enquiry == null)
        //     {
        //         return NotFound();
        //     }

        //     return View(enquiry);
        // }

        // // GET: Enquiry/Create
        // [Authorize]
        // public IActionResult Create()
        // {
        //     return View();
        // }

        // // POST: Enquiry/Create
        // // To protect from overposting attacks, enable the specific properties you want to bind to.
        // // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [Authorize]
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Create([Bind("Id,Email,CreatedOn,Content,Status")] Enquiry enquiry)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         _context.Add(enquiry);
        //         await _context.SaveChangesAsync();
        //         return RedirectToAction(nameof(Index));
        //     }
        //     return View(enquiry);
        // }

        // // GET: Enquiry/Edit/5
        // [Authorize]
        // public async Task<IActionResult> Edit(int? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     var enquiry = await _context.Enquiry.FindAsync(id);
        //     if (enquiry == null)
        //     {
        //         return NotFound();
        //     }
        //     return View(enquiry);
        // }

        // // POST: Enquiry/Edit/5
        // // To protect from overposting attacks, enable the specific properties you want to bind to.
        // // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [Authorize]
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Edit(int id, [Bind("Id,Email,CreatedOn,Content,Status")] Enquiry enquiry)
        // {
        //     if (id != enquiry.Id)
        //     {
        //         return NotFound();
        //     }

        //     if (ModelState.IsValid)
        //     {
        //         try
        //         {
        //             _context.Update(enquiry);
        //             await _context.SaveChangesAsync();
        //         }
        //         catch (DbUpdateConcurrencyException)
        //         {
        //             if (!EnquiryExists(enquiry.Id))
        //             {
        //                 return NotFound();
        //             }
        //             else
        //             {
        //                 throw;
        //             }
        //         }
        //         return RedirectToAction(nameof(Index));
        //     }
        //     return View(enquiry);
        // }

        // // GET: Enquiry/Delete/5
        // [Authorize]
        // public async Task<IActionResult> Delete(int? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     var enquiry = await _context.Enquiry
        //         .FirstOrDefaultAsync(m => m.Id == id);
        //     if (enquiry == null)
        //     {
        //         return NotFound();
        //     }

        //     return View(enquiry);
        // }

        // // POST: Enquiry/Delete/5
        // [Authorize]
        // [HttpPost, ActionName("Delete")]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> DeleteConfirmed(int id)
        // {
        //     var enquiry = await _context.Enquiry.FindAsync(id);
        //     if (enquiry != null)
        //     {
        //         _context.Enquiry.Remove(enquiry);
        //     }

        //     await _context.SaveChangesAsync();
        //     return RedirectToAction(nameof(Index));
        // }

        // private bool EnquiryExists(int id)
        // {
        //     return _context.Enquiry.Any(e => e.Id == id);
        // }
    }
}
