using End_Project.Data;
using End_Project.Models;
using End_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace End_Project.Controllers
{
    public class HeartController : Controller
    {
        private readonly AppDbContext _context;
        public HeartController(AppDbContext context)
        {
            _context= context;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Header> headers = await _context.Headers.Where(m => !m.IsDeleted).ToListAsync();

            HeartVM model = new HeartVM
            {
                Headers = headers,
            };

            return View(model);
        }
    }
}
