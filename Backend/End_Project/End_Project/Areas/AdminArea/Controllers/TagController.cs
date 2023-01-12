using End_Project.Data;
using End_Project.Helpers;
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
    public class TagController : Controller
    {
        private readonly AppDbContext _context;
        public TagController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Tag> tags = await _context.Tags.Where(m => !m.IsDeleted).ToListAsync();
            return View(tags);
        }



        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Tag tag)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }


                bool isExist = await _context.Tags.AnyAsync(m => m.Name.Trim() == tag.Name.Trim());

                if (isExist)
                {
                    ModelState.AddModelError("Name", "Tag already exist");
                    return View();
                }


                await _context.Tags.AddAsync(tag);

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

            Tag tag = await _context.Tags.FindAsync(id);

            if (tag == null) return NotFound();

            return View(tag);
        }




        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null) return BadRequest();

                Tag tag = await _context.Tags.FirstOrDefaultAsync(m => m.Id == id);

                if (tag == null) return NotFound();

                return View(tag);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Tag tag)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return View();
                }

                Tag dbTag = await _context.Tags.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

                if (dbTag == null) return NotFound();

                if (dbTag.Name.Trim().ToLower() == tag.Name.Trim().ToLower())
                {
                    return RedirectToAction(nameof(Index));
                }

                _context.Tags.Update(tag);

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

            Tag tag = await GetByIdAsync(id);

            if (tag == null) return NotFound();

            _context.Tags.Remove(tag);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }



        private async Task<Tag> GetByIdAsync(int id)
        {
            return await _context.Tags.FindAsync(id);
        }
    }
}
