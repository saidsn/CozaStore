using End_Project.Data;
using End_Project.Models;
using End_Project.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace End_Project.Controllers
{
    public class BlogDetailController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManagar;
        public BlogDetailController(AppDbContext context, UserManager<AppUser> userManagar)
        {
            _context = context;
            _userManagar = userManagar;
        }

        public async Task<IActionResult> Index(int? id)
        {
            IEnumerable<Header> headers = await _context.Headers.Where(m => !m.IsDeleted).ToListAsync();
            Blog blog = await _context.Blogs
                .Where(m => !m.IsDeleted && m.Id == id)
                .Include(m => m.BlogCategory)
                .Include(m => m.BlogTags)
                .ThenInclude(m => m.Tag)
                .Include(m => m.BlogComments)
                .ThenInclude(m => m.AppUser)
                .FirstOrDefaultAsync();
            IEnumerable<BlogComment> blogComments = await _context.BlogComments.Where(m => !m.IsDeleted && m.BlogId == id).ToListAsync();
            IEnumerable<BlogCategory> blogCategories = await _context.BlogCategories.Where(m => !m.IsDeleted).ToListAsync();
            IEnumerable<Blog> recentPost = await _context.Blogs.Where(m => !m.IsDeleted).OrderByDescending(m => m.Id).ToListAsync();
            List<BlogTag> blogTags = await _context.BlogTags.Where(m => m.BlogId == id).ToListAsync();
            List<Tag> tags = new List<Tag>();
            foreach (var blogTag in blogTags)
            {
                Tag dbTag = await _context.Tags.Where(m => m.Id == blogTag.TagId).FirstOrDefaultAsync();
                tags.Add(dbTag);
            }

            BlogDetailVM model = new BlogDetailVM
            {
                Headers = headers,
                Blog = blog,
                BlogCategories = blogCategories,
                RecentPosts = recentPost,
                Tags = tags,
                BlogComment = new BlogComment(),
                BlogComments = blogComments
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(BlogComment blogComment)
        {
            Blog blog = await _context.Blogs
                .Where(m => !m.IsDeleted && m.Id == blogComment.BlogId)
                .Include(m => m.BlogCategory)
                .Include(m => m.BlogTags)
                .ThenInclude(m => m.Tag)
                .Include(m => m.BlogComments)
                .ThenInclude(m => m.AppUser)
                .FirstOrDefaultAsync();

            AppUser user = await _userManagar.GetUserAsync(User);
            Blog blog1 = await _context.Blogs.FirstOrDefaultAsync(m => m.Id == blogComment.BlogId);

            blogComment.AppUser = user;
            blogComment.AppUserId = user.Id;
            blogComment.CreateDate = DateTime.Now;
            blogComment.Blog = blog;

            await _context.BlogComments.AddAsync(blogComment);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", new { id = blog.Id });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveComment(int id)
        {

            BlogComment blogComment = await _context.BlogComments.FirstOrDefaultAsync(m => m.Id == id);


            blogComment.IsDeleted = true;

            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { id = blogComment.BlogId });
        }
    }
}
