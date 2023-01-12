using End_Project.Data;
using End_Project.Helpers.Enums;
using End_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace End_Project.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [Authorize(Roles = "SuperAdmin,Admin,Member")]
    public class BlogCategoryController : Controller
    {
        private readonly AppDbContext _context;
        public BlogCategoryController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<BlogCategory> blogCategories = await _context.BlogCategories.Where(m => !m.IsDeleted).ToListAsync();
            return View(blogCategories);
        }



        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BlogCategory blogCategory)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }


                bool isExist = await _context.BlogCategories.AnyAsync(m => m.Name.Trim() == blogCategory.Name.Trim());

                if (isExist)
                {
                    ModelState.AddModelError("Name", "BlogCategory already exist");
                    return View();
                }


                await _context.BlogCategories.AddAsync(blogCategory);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }


        }




        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return BadRequest();

            BlogCategory blogCategory = await _context.BlogCategories.FindAsync(id);

            if (blogCategory == null) return NotFound();

            return View(blogCategory);
        }




        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null) return BadRequest();

                BlogCategory blogCategory = await _context.BlogCategories.FirstOrDefaultAsync(m => m.Id == id);

                if (blogCategory == null) return NotFound();

                return View(blogCategory);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BlogCategory blogCategory)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return View();
                }

                BlogCategory dbBlogCategory = await _context.BlogCategories.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

                if (dbBlogCategory == null) return NotFound();

                if (dbBlogCategory.Name.Trim().ToLower() == blogCategory.Name.Trim().ToLower())
                {
                    return RedirectToAction(nameof(Index));
                }

                _context.BlogCategories.Update(blogCategory);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }

        }




        [HttpPost]
        [Authorize(Roles = "SuperAdmin,Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            BlogCategory blogCategory = await GetByIdAsync(id);

            if (blogCategory == null) return NotFound();

            _context.BlogCategories.Remove(blogCategory);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }



        private async Task<BlogCategory> GetByIdAsync(int id)
        {
            return await _context.BlogCategories.FindAsync(id);
        }
    }
}
