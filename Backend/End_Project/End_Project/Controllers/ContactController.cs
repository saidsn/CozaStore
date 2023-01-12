using End_Project.Data;
using End_Project.Models;
using End_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace End_Project.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;

        public ContactController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Header> header = await _context.Headers.Where(m => !m.IsDeleted).ToListAsync();
            Contact contact = await _context.Contacts.Where(m => !m.IsDeleted).FirstOrDefaultAsync();
            ContactInfo contactInfo = await _context.ContactInfos.Where(m => !m.IsDeleted).FirstOrDefaultAsync();
            Map map = await _context.Maps.Where(m => !m.IsDeleted).FirstOrDefaultAsync();

            ContactVM model = new ContactVM
            {
                Headers = header,
                Map = map,
                ContactInfo= contactInfo,
            };

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Contact contact)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return RedirectToAction(nameof(Index));
                }

                bool isExsist = await _context.Contacts.AnyAsync(m => m.Name.Trim() == contact.Name.Trim()
                      && m.Email.Trim() == contact.Email.Trim()
                      && m.Subject.Trim() == contact.Subject.Trim()
                      && m.Message.Trim() == contact.Message.Trim());



                if (isExsist)
                {
                    ModelState.AddModelError("Name", "Subject is already exist");
                    return View();
                }
                await _context.Contacts.AddAsync(contact);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));

            }
            catch (Exception)
            {

                return View();
            }
        }
    }
}
