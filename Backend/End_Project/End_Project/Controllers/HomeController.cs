using End_Project.Data;
using End_Project.Models;
using End_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace End_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Slider> sliders = await _context.Sliders.Where(m => !m.IsDeleted).ToListAsync();
            IEnumerable<Banner> banners = await _context.Banners.Where(m => !m.IsDeleted).ToListAsync();
            IEnumerable<Service> services = await _context.Services.Where(m => !m.IsDeleted).ToListAsync();
            IEnumerable<Brend> brends = await _context.Brends.Where(m => !m.IsDeleted).ToListAsync();
            IEnumerable<Product> products = await _context.Products.Where(m => !m.IsDeleted)
                .Include(m => m.ProductImages)
                .Include(m => m.Brend)
                .Include(m => m.Category)
                .Include(m => m.ProductSizes)
                .Take(6)
                .ToListAsync();



            HomeVM model = new HomeVM
            {
                Sliders = sliders,
                Banners = banners,
                Services = services,
                Brends = brends,
                Products = products,
            };

            return View(model);
        }


        public IActionResult Search(string search)
        {
            List<Product> searchName = _context.Products.Where(s => !s.IsDeleted && s.Name.Trim().Contains(search.Trim())).Include(m => m.ProductImages).ToList();
            return PartialView("_SearchProduct", searchName);
        }


    }
}
