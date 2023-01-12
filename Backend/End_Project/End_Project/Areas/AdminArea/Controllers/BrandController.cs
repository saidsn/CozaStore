using End_Project.Data;
using End_Project.Helpers;
using End_Project.Helpers.Enums;
using End_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace End_Project.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [Authorize(Roles = "SuperAdmin,Admin,Member")]
    public class BrandController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public BrandController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Brend> brends = await _context.Brends.Where(m => !m.IsDeleted).ToListAsync();
            return View(brends);
        }



        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Brend brand)
        {
            if (!ModelState.IsValid) return View();

            if (!brand.Photo.CheckFileType("image/"))
            {
                ModelState.AddModelError("Photo", "Please choose correct image type");
                return View();
            }

            if (!brand.Photo.CheckFileSize(200))
            {
                ModelState.AddModelError("Photo", "Please choose correct image size");
                return View();
            }

            string fileName = Guid.NewGuid().ToString() + "_" + brand.Photo.FileName;

            string path = Helper.GetFilePath(_env.WebRootPath, "assets/images/brand", fileName);

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await brand.Photo.CopyToAsync(stream);
            }

            brand.Image = fileName;

            await _context.Brends.AddAsync(brand);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }



        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return BadRequest();

            Brend brand = await _context.Brends.FindAsync(id);

            if (brand == null) return NotFound();

            return View(brand);
        }



        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id is null) return BadRequest();

                Brend brand = await _context.Brends.FirstOrDefaultAsync(m => m.Id == id);

                if (brand is null) return NotFound();

                return View(brand);

            }
            catch (Exception ex)
            {

                ViewBag.Message = ex.Message;
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Brend brand)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(brand);
                }

                if (!brand.Photo.CheckFileType("image/"))
                {
                    ModelState.AddModelError("Photo", "Please choose correct image type");
                    return View();
                }

                string fileName = Guid.NewGuid().ToString() + "_" + brand.Photo.FileName;

                Brend dbBrand = await _context.Brends.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

                if (dbBrand is null) return NotFound();

                if (dbBrand.Photo == brand.Photo)
                {
                    return RedirectToAction(nameof(Index));
                }

                string path = Helper.GetFilePath(_env.WebRootPath, "assets/images/brand", fileName);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    await brand.Photo.CopyToAsync(stream);
                }

                brand.Image = fileName;

                _context.Brends.Update(brand);

                await _context.SaveChangesAsync();

                string dbPath = Helper.GetFilePath(_env.WebRootPath, "assets/images/brand", dbBrand.Image);

                Helper.DeleteFile(dbPath);

                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {

                ViewBag.Message = ex.Message;
                return View();
            }
        }


        [Authorize(Roles = "SuperAdmin,Admin")]
        public async Task<IActionResult> Delete(int id)
        {

            Brend brand = await GetByIdAsync(id);

            if (brand == null) return NotFound();

            string path = Helper.GetFilePath(_env.WebRootPath, "assets/images/brand", brand.Image);

            Helper.DeleteFile(path);

            _context.Brends.Remove(brand);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        private async Task<Brend> GetByIdAsync(int id)
        {
            return await _context.Brends.FindAsync(id);
        }
    }
}
