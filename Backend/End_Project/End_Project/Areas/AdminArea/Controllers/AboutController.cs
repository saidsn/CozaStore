using End_Project.Data;
using End_Project.Helpers;
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
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public AboutController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        
        public async Task<IActionResult> Index()
        {
            IEnumerable<About> abouts = await _context.Abouts.Where(m => !m.IsDeleted).ToListAsync();
            return View(abouts);
        }

       
        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(About about)
        {
            if (!ModelState.IsValid) return View();

            if (!about.Photo.CheckFileType("image/"))
            {
                ModelState.AddModelError("Photo", "Please choose correct image type");
                return View();
            }

            if (!about.Photo.CheckFileSize(200))
            {
                ModelState.AddModelError("Photo", "Please choose correct image size");
                return View();
            }

            string fileName = Guid.NewGuid().ToString() + "_" + about.Photo.FileName;

            string path = Helper.GetFilePath(_env.WebRootPath, "assets/images/about", fileName);

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await about.Photo.CopyToAsync(stream);
            }

            about.Image = fileName;

            await _context.Abouts.AddAsync(about);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }



        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return BadRequest();

            About about = await _context.Abouts.FindAsync(id);

            if (about == null) return NotFound();

            return View(about);
        }



        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id is null) return BadRequest();

                About about = await _context.Abouts.FirstOrDefaultAsync(m => m.Id == id);

                if (about is null) return NotFound();

                return View(about);

            }
            catch (Exception ex)
            {

                ViewBag.Message = ex.Message;
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, About about)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(about);
                }

                if (!about.Photo.CheckFileType("image/"))
                {
                    ModelState.AddModelError("Photo", "Please choose correct image type");
                    return View();
                }

                string fileName = Guid.NewGuid().ToString() + "_" + about.Photo.FileName;

                About dbAbout = await _context.Abouts.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

                if (dbAbout is null) return NotFound();

                if (dbAbout.Photo == about.Photo)
                {
                    return RedirectToAction(nameof(Index));
                }

                string path = Helper.GetFilePath(_env.WebRootPath, "assets/images/about", fileName);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    await about.Photo.CopyToAsync(stream);
                }

                about.Image = fileName;

                _context.Abouts.Update(about);

                await _context.SaveChangesAsync();

                string dbPath = Helper.GetFilePath(_env.WebRootPath, "assets/images/about", dbAbout.Image);

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

            About about = await GetByIdAsync(id);

            if (about == null) return NotFound();

            string path = Helper.GetFilePath(_env.WebRootPath, "assets/images/about", about.Image);

            Helper.DeleteFile(path);

            _context.Abouts.Remove(about);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }



        private async Task<About> GetByIdAsync(int id)
        {
            return await _context.Abouts.FindAsync(id);
        }
    }
}
