using End_Project.Data;
using End_Project.Helpers.Enums;
using End_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace End_Project.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [Authorize(Roles = "SuperAdmin,Admin,Member")]
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;
        public ContactController(AppDbContext context)
        {
            _context= context;
        }
       
        public async Task<IActionResult> Index()
        {
           IEnumerable<Contact> contacts = await _context.Contacts.Where(m => !m.IsDeleted).ToListAsync();
            return View(contacts);
        }


        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return BadRequest();

            Contact contact = await _context.Contacts.FindAsync(id);

            if (contact == null) return NotFound();

            return View(contact);
        }
    }
}
