using End_Project.Data;
using End_Project.Helpers.Enums;
using End_Project.Models;
using End_Project.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Size = End_Project.Models.Size;

namespace End_Project.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [Authorize(Roles = "SuperAdmin,Admin,Member")]
    public class SizeController : Controller
    {
        private readonly AppDbContext _context;
        public SizeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Size> sizes = await _context.Sizes.Where(m => !m.IsDeleted).ToListAsync();
            return View(sizes);
        }




        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Size size)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }


                bool isExist = await _context.Sizes.AnyAsync(m => m.Name.Trim() == size.Name.Trim());

                if (isExist)
                {
                    ModelState.AddModelError("Name", "Size already exist");
                    return View();
                }


                await _context.Sizes.AddAsync(size);

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

            Size size = await _context.Sizes.FindAsync(id);

            if (size == null) return NotFound();

            return View(size);
        }




        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null) return BadRequest();

                Size size = await _context.Sizes.FirstOrDefaultAsync(m => m.Id == id);

                if (size == null) return NotFound();

                return View(size);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Size size)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return View();
                }

                Size dbSize = await _context.Sizes.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

                if (dbSize == null) return NotFound();

                if (dbSize.Name.Trim().ToLower() == size.Name.Trim().ToLower())
                {
                    return RedirectToAction(nameof(Index));
                }

                _context.Sizes.Update(size);

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
            Size size = await GetByIdAsync(id);

            if (size == null) return NotFound();

            _context.Sizes.Remove(size);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }



        private async Task<Size> GetByIdAsync(int id)
        {
            return await _context.Sizes.FindAsync(id);
        }
    }
}
