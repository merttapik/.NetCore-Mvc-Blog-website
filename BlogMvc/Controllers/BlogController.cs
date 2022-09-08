using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogMvc.Controllers
{
    
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        Context c = new Context();
        [AllowAnonymous]
        public IActionResult Index()
        {
            var values = bm.GetWithCategory();
            return View(values);
        }
        [AllowAnonymous]
        public IActionResult BlogDetails(int id)
        {
            ViewBag.i = id;
            var values = bm.GetBlogById(id);
            return View(values);
        }
        [AllowAnonymous]
        public IActionResult BlogListByWriter()
        {
            var usermail = User.Identity.Name;
            var writerId = c.Writers.Where(x => x.WriterName == usermail).Select(y => y.WriterId).FirstOrDefault();
            var values = bm.GetListWriterCategory(writerId);
            return View(values);
        }
        [HttpGet]
        public IActionResult BlogAdd()
        {
          
            List<SelectListItem> categoryValues = (from x in cm.GetListAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryValues;
            return View();
        }
        [HttpPost]
        public IActionResult BlogAdd(Blog b)
        {
            var username = User.Identity.Name;
            var writerId = c.Writers.Where(x => x.WriterName == username).Select(y => y.WriterId).FirstOrDefault();
            BlogValidation bv = new BlogValidation();
            ValidationResult results = bv.Validate(b);
            List<SelectListItem> categoryValues = (from x in cm.GetListAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryValues;
            if (results.IsValid)
            {
                
                b.BlogStatus = true;
                b.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                b.WriterId = writerId;
               
                bm.Add(b);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public IActionResult BlogDelete(int id)
        {
            var blogvalue = bm.GetById(id);
            bm.Delete(blogvalue);
            return RedirectToAction("BlogListByWriter", "Blog");

        }
        [HttpGet]
        public IActionResult BlogEdit(int id)
        {
            var blogvalue = bm.GetById(id);
            List<SelectListItem> categoryValues = (from x in cm.GetListAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryValues;
            return View(blogvalue);
        }
        [HttpPost]
        public IActionResult BlogEdit(Blog blog)
        {
            var blogValue = bm.GetById(blog.BlogId);
            blog.BlogCreateDate = DateTime.Parse(blogValue.BlogCreateDate.ToShortDateString());
            blog.BlogStatus = true;
            bm.Update(blog);
            return RedirectToAction("BlogListByWriter", "Blog");
        }
    }
}
