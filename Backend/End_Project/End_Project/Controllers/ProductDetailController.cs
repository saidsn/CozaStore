using End_Project.Data;
using End_Project.Models;
using End_Project.Services;
using End_Project.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace End_Project.Controllers
{
    public class ProductDetailController : Controller
    {
        private readonly AppDbContext _context;
        private readonly LayoutService _layoutService;
        private readonly UserManager<AppUser> _userManagar;
        public ProductDetailController(AppDbContext context, LayoutService layoutService, UserManager<AppUser> userManagar)
        {
            _context = context;
            _layoutService = layoutService;
            _userManagar = userManagar;
        }

        public async Task<IActionResult> Index(int? id)
        {
            IEnumerable<Header> headers = await _context.Headers.Where(m => !m.IsDeleted).ToListAsync();
            Dictionary<string, string> setting = await _layoutService.GetDatasFromSetting();
            Product products = await _context.Products
                 .Where(m => !m.IsDeleted && m.Id == id)
                 .Include(m => m.ProductImages)
                 .Include(m => m.Brend)
                 .Include(m => m.Category)
                 .Include(m => m.ProductSizes)
                 .ThenInclude(m => m.Size)
                 .Include(m => m.Comments)
                 .ThenInclude(m=>m.AppUser)
                 .FirstOrDefaultAsync();
            IEnumerable<Comment> comments = await _context.Comments.Where(m=>!m.IsDeleted && m.ProductId == id).ToListAsync();

            ProductDetailVM model = new ProductDetailVM
            {
                Headers = headers,
                Product = products,
                Settings = setting,
                Comment = new Comment(),
                ProductComments = comments
            };

            return View(model);
        }



        [HttpPost]
        public async Task<IActionResult> CreateComment(Comment comment)
        {
            Product product = await _context.Products
               .Where(m => !m.IsDeleted && m.Id == comment.ProductId)
               .Include(m => m.ProductImages)
               .Include(m => m.Category)
               .Include(m => m.Brend)
               .Include(m => m.ProductSizes)
               .ThenInclude(m => m.Size)
               .Include(m => m.Comments)
               .ThenInclude(m => m.AppUser)
               .FirstOrDefaultAsync();

            AppUser user = await _userManagar.GetUserAsync(User);
            Product product1 = await _context.Products
                 .Include(m => m.ProductImages)
                .FirstOrDefaultAsync(m => m.Id == comment.ProductId);


            comment.AppUser = user;
            comment.AppUserId = user.Id;
            comment.CreateDate = DateTime.Now;
            comment.Product = product;

            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", new { id = product.Id });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveComment(int id)
        {

            Comment comment = await _context.Comments.FirstOrDefaultAsync(m => m.Id == id);


            comment.IsDeleted = true;

            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { id = comment.ProductId });
        }





    }
}
