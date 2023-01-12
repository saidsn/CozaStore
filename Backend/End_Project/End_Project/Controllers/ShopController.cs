using End_Project.Data;
using End_Project.Models;
using End_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace End_Project.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDbContext _context;
        public ShopController(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index(int? id)
        {
            ViewBag.count = await _context.Products.Where(m => !m.IsDeleted).CountAsync();
            if (id is null)
            {
                ViewBag.count = await _context.Products.Where(m => !m.IsDeleted).CountAsync();
                IEnumerable<Category> categories = await _context.Categories.Where(m => !m.IsDeleted).ToListAsync();
                IEnumerable<Brend> brends = await _context.Brends.Where(m => !m.IsDeleted).ToListAsync();
                IEnumerable<Product> products = await _context.Products.Where(m => !m.IsDeleted)
                 .Include(m => m.ProductImages)
                 .Include(m => m.Brend)
                 .Include(m => m.Category)
                 .Include(m => m.ProductSizes)
                 .Take(9)
                 .ToListAsync();

                ShopVM model = new ShopVM
                {
                    Categories = categories,
                    Brends = brends,
                    Products = products
                };

                return View(model);
            }
            else
            {
                 ViewBag.count = await _context.Products.Where(m => !m.IsDeleted).CountAsync();
                IEnumerable<Category> categories = await _context.Categories.Where(m => !m.IsDeleted).ToListAsync();
                IEnumerable<Brend> brends = await _context.Brends.Where(m => !m.IsDeleted).ToListAsync();
                IEnumerable<Product> products = await _context.Products.Where(m => !m.IsDeleted && m.BrendId == id)
                 .Include(m => m.ProductImages)
                 .Include(m => m.Brend)
                 .Include(m => m.Category)
                 .Include(m => m.ProductSizes)
                 .Take(9)
                 .ToListAsync();

                ShopVM model = new ShopVM
                {
                    Categories = categories,
                    Brends = brends,
                    Products = products
                };

                return View(model);
            }
        }

       

        public async Task<IActionResult> LoadMore(int skip)
        {
            IEnumerable<Product> products = await _context.Products.Where(m => !m.IsDeleted)
             .Include(m => m.ProductImages)
             .Include(m => m.Brend)
             .Include(m => m.Category)
             .Include(m => m.ProductSizes)
             .Skip(skip)
             .Take(3)
             .ToListAsync();

            return PartialView("_ProductsPartial", products);
        }

  

        public IActionResult Search(string search)
        {
            List<Product> searchName = _context.Products.Where(s => !s.IsDeleted && s.Name.Trim().Contains(search.Trim())).Include(m => m.ProductImages).ToList();
            return PartialView("_Search", searchName);
        }
    }
}
