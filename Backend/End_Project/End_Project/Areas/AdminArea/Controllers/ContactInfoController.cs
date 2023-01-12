using End_Project.Data;
using End_Project.Helpers.Enums;
using End_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace End_Project.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [Authorize(Roles = "SuperAdmin,Admin,Member")]
    public class ContactInfoController : Controller
    {
        private readonly AppDbContext _context;
        public ContactInfoController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ContactInfo contactInfo = await _context.ContactInfos.Where(m => !m.IsDeleted).FirstOrDefaultAsync();
            return View(contactInfo);
        }


        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return BadRequest();

            ContactInfo contactInfo = await _context.ContactInfos.FindAsync(id);

            if (contactInfo == null) return NotFound();

            return View(contactInfo);
        }




        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null) return BadRequest();

                ContactInfo contactInfo = await _context.ContactInfos.FirstOrDefaultAsync(m => m.Id == id);

                if (contactInfo == null) return NotFound();

                return View(contactInfo);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ContactInfo contactInfo)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return View();
                }

                ContactInfo dbContactInfo = await _context.ContactInfos.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

                if (dbContactInfo == null) return NotFound();

                if (dbContactInfo.Phone.Trim().ToLower() == dbContactInfo.Phone.Trim().ToLower())
                {
                    return RedirectToAction(nameof(Index));
                }

                _context.ContactInfos.Update(contactInfo);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }

        }


        private async Task<ContactInfo> GetByIdAsync(int id)
        {
            return await _context.ContactInfos.FindAsync(id);
        }
    }
}
