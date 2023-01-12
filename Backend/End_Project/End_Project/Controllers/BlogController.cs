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
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;

        public BlogController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Header> headers = await _context.Headers.Where(m => !m.IsDeleted).ToListAsync();
            IEnumerable<Blog> blogs = await _context.Blogs.Where(m => !m.IsDeleted).ToListAsync();
            IEnumerable<BlogCategory> blogCategories = await _context.BlogCategories.Where(m => !m.IsDeleted).ToListAsync();
            IEnumerable<Blog> recentPost = await _context.Blogs.Where(m => !m.IsDeleted).OrderByDescending(m => m.Id).ToListAsync();
            IEnumerable<Tag> tags = await _context.Tags.Where(m => !m.IsDeleted).ToListAsync();

            BlogVM model = new BlogVM
            {
                Headers = headers,
                Blogs= blogs,
                BlogCategories= blogCategories,
                RecentPosts= recentPost,
                Tags= tags

            };

            return View(model);
        }
        public async Task<IActionResult> BlogForCategory(int Id)
        {
            IEnumerable<Header> headers = await _context.Headers.Where(m => !m.IsDeleted).ToListAsync();
            IEnumerable<Blog> blogs = await _context.Blogs.Where(m => !m.IsDeleted).Where(m=>m.BlogCategoryId == Id).ToListAsync();
            IEnumerable<Blog> recentPost = await _context.Blogs.Where(m => !m.IsDeleted).OrderByDescending(m => m.Id).ToListAsync();

            BlogVM model = new BlogVM
            {
                Headers = headers,
                Blogs = blogs,
                RecentPosts = recentPost,
            };

            return View(model);
        }
    }
}
