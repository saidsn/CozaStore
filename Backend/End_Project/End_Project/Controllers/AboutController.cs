using End_Project.Data;
using End_Project.Models;
using End_Project.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace End_Project.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;

        public AboutController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult> Index()
        {
            IEnumerable<Header> headers = await _context.Headers.Where(m => !m.IsDeleted).ToListAsync();
            IEnumerable<About> abouts = await _context.Abouts.Where(m=>!m.IsDeleted).ToListAsync();


            AboutVM model = new AboutVM
            {
               Headers= headers,
               Abouts= abouts
            };
            return View(model);
        }
    }
}
