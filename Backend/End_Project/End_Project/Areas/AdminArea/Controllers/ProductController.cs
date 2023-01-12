﻿using End_Project.Data;
using End_Project.Helpers;
using End_Project.Models;
using End_Project.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using End_Project.ViewModels.Product;
using End_Project.Helpers.Enums;
using Microsoft.AspNetCore.Authorization;

namespace End_Project.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [Authorize(Roles = "SuperAdmin,Admin,Member")]
    public class ProductController : Controller
    {
     
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
       

       
        public ProductController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
  

        
        public async Task<IActionResult> Index(int page = 1, int take = 5)
        {
            List<Product> products = await _context.Products
                .Where(m => !m.IsDeleted)
                .Include(m => m.ProductImages)
                .Include(m => m.Category)
                .Include(m => m.Brend)
                .OrderByDescending(m => m.Id)
                .Skip((page * take) - take)
                .Take(take)
                .ToListAsync();

            ViewBag.take = take;

            List<ProductListVM> mapDatas = GetMapDatas(products);

            int count = await GetPageCount(take);

            Paginate<ProductListVM> result = new Paginate<ProductListVM>(mapDatas, page, count);

            return View(result);
        }
    

        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Create()
        {
            ViewBag.categories = await GetCategoriesAsync();
            ViewBag.brands = await GetBrandAsync();
            var data = await GetSizesAsync();

            ProductCreateVM productCreateVM = new ProductCreateVM()
            {
                Size = data
            };


            return View(productCreateVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateVM product)
        {
            ViewBag.categories = await GetCategoriesAsync();
            ViewBag.brands = await GetBrandAsync();

            if (!ModelState.IsValid)
            {
                return View(product);
            }

            foreach (var photo in product.Photos)
            {
                if (!photo.CheckFileType("image/"))
                {
                    ModelState.AddModelError("Photo", "Please choose correct image type");
                    return View(product);
                }


                if (!photo.CheckFileSize(500))
                {
                    ModelState.AddModelError("Photo", "Please choose correct image size");
                    return View(product);
                }

            }

            List<ProductImage> images = new List<ProductImage>();

            foreach (var photo in product.Photos)
            {
                string fileName = Guid.NewGuid().ToString() + "_" + photo.FileName;

                string path = Helper.GetFilePath(_env.WebRootPath, "assets/images/product", fileName);

                await Helper.SaveFile(path, photo);


                ProductImage image = new ProductImage
                {
                    Image = fileName,
                };

                images.Add(image);
            }

            images.FirstOrDefault().IsMain = true;

            decimal convertedPrice = decimal.Parse(product.Price.Replace(".", ","));

            Product newProduct = new Product
            {
                ProductImages = images,
                Name = product.Name,
                CategoryId = product.CategoryId,
                BrendId = product.BrandId,
                Price = (int)convertedPrice,
                CreateDate = DateTime.Now,
                Description = product.Description,
              
            };

            await _context.Products.AddAsync(newProduct);

            await _context.SaveChangesAsync();


            foreach (var item in product.Size.Where(m => m.IsSelected))
            {
                ProductSize product_Size = new ProductSize
                {
                    ProductId = newProduct.Id,
                    SizeId = item.Id,
                };
                await _context.ProductSizes.AddAsync(product_Size);
            }

            _context.ProductImages.UpdateRange(images);
            _context.Products.Update(newProduct);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }



        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Product product = await _context.Products
            .Where(m => !m.IsDeleted && m.Id == id)
            .Include(m => m.ProductImages)
                .Include(m => m.Category)
                .Include(m => m.Brend)
                .FirstOrDefaultAsync();

            List<ProductSize> productSizes = await _context.ProductSizes.Where(m => m.ProductId == id).ToListAsync();
            List<Size> sizes = new List<Size>();
            foreach (var size in productSizes)
            {
                Size dbSize = await _context.Sizes.Where(m => m.Id == size.SizeId).FirstOrDefaultAsync();
                sizes.Add(dbSize);
            }

            if (product == null)
            {
                return NotFound();
            }
            var data = await GetSizesAsync();

            ProductFeaturedVM productDetail = new ProductFeaturedVM
            {
                Id = product.Id,
                ProductImages = product.ProductImages,
                Name = product.Name,
                Description= product.Description,
                CategoryName = product.Category.Name,
                BrandName = product.Brend.Name,
                Price = product.Price,
                Sizes = sizes,
            };

            return View(productDetail);
        }



        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return BadRequest();

            ViewBag.brands = await GetBrandAsync();
            ViewBag.categories = await GetCategoriesAsync();

            Product product = await GetByIdAsync((int)id);

            return View(new ProductEditVM
            {
                Id = product.Id,
                Images = product.ProductImages,
                Name = product.Name,
                CategoryId = product.CategoryId,
                BrandId = product.BrendId,
                Price = product.Price.ToString("0.#####").Replace(",", "."),
                Description = product.Description,
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductEditVM updatedProduct)
        {
            ViewBag.categories = await GetCategoriesAsync();
            ViewBag.brands = await GetBrandAsync();

            if (!ModelState.IsValid) return View(updatedProduct);

            Product product = await GetByIdAsync(id);

            if (updatedProduct.Photos != null)
            {

                foreach (var photo in updatedProduct.Photos)
                {
                    if (!photo.CheckFileType("image/"))
                    {
                        ModelState.AddModelError("Photo", "Please choose correct image type");
                        return View(updatedProduct);
                    }


                    if (!photo.CheckFileSize(500))
                    {
                        ModelState.AddModelError("Photo", "Please choose correct image size");
                        return View(updatedProduct);
                    }

                }

                foreach (var item in product.ProductImages)
                {
                    string path = Helper.GetFilePath(_env.WebRootPath, "img", item.Image);
                    Helper.DeleteFile(path);
                }


                List<ProductImage> images = new List<ProductImage>();

                foreach (var photo in updatedProduct.Photos)
                {

                    string fileName = Guid.NewGuid().ToString() + "_" + photo.FileName;

                    string path = Helper.GetFilePath(_env.WebRootPath, "assets/images/product", fileName);

                    await Helper.SaveFile(path, photo);


                    ProductImage image = new ProductImage
                    {
                        Image = fileName,
                    };

                    images.Add(image);

                }

                images.FirstOrDefault().IsMain = true;

                product.ProductImages = images;

            }

            decimal convertedPrice = StringToDecimal(updatedProduct.Price);

            product.Name = updatedProduct.Name;
            product.CategoryId = updatedProduct.CategoryId;
            product.BrendId = updatedProduct.BrandId;
            product.Price = (int)convertedPrice;
            product.Description = updatedProduct.Description;


            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin,Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            Product product = await _context.Products
                .Where(m => !m.IsDeleted && m.Id == id)
                .Include(m => m.ProductImages)
                .FirstOrDefaultAsync();

            if (product == null) return NotFound();

            foreach (var item in product.ProductImages)
            {
                string path = Helper.GetFilePath(_env.WebRootPath, "img", item.Image);
                Helper.DeleteFile(path);
                item.IsDeleted = true;
            }

            product.IsDeleted = true;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }






        private decimal StringToDecimal(string str)
        {
            return decimal.Parse(str.Replace(".", ","));
        }

        private async Task<SelectList> GetCategoriesAsync()
        {
            IEnumerable<Category> categories = await _context.Categories.Where(m => !m.IsDeleted).ToListAsync();
            return new SelectList(categories, "Id", "Name");
        }

        private async Task<SelectList> GetBrandAsync()
        {
            IEnumerable<Brend> brends = await _context.Brends.Where(m => !m.IsDeleted).ToListAsync();
            return new SelectList(brends, "Id", "Name");
        }

        private async Task<List<Size>> GetSizesAsync()
        {
            List<Size> sizes = await _context.Sizes.Where(m => !m.IsDeleted).ToListAsync();
            return sizes;
        }

        private async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products
                .Where(m => !m.IsDeleted && m.Id == id)
                .Include(m => m.Category)
                .Include(m => m.ProductImages)
                .FirstOrDefaultAsync();
        }

        private List<ProductListVM> GetMapDatas(List<Product> products)
        {
            List<ProductListVM> productList = new List<ProductListVM>();

            foreach (var product in products)
            {
                ProductListVM newProduct = new ProductListVM
                {
                    Id = product.Id,
                    MainImage = product.ProductImages.FirstOrDefault(m=>m.IsMain)?.Image,
                    Name = product.Name,
                    Brand = product.Brend.Name,
                    Category = product.Category.Name,
                    Price = product.Price
                };

                productList.Add(newProduct);
            }

            return productList;
        }

        private async Task<int> GetPageCount(int take)
        {
            int productCount = await _context.Products.Where(m => !m.IsDeleted).CountAsync();

            return (int)Math.Ceiling((decimal)productCount / take);
        }
    }
}
