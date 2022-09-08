using BlogMvc.Models;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlogMvc.Controllers
{
    [Authorize(Roles ="User")]
    public class WriterController : Controller
    {

        WriterManager wm = new WriterManager(new EfWriterRepository());
  
        public IActionResult Index()
        {
           
            return View();
        }
        
        public IActionResult Test()
        {
            return View();
        }
        [HttpGet]
        public IActionResult WriterEditProfile()
        {
            Context c = new Context();
            var username = User.Identity.Name;
            var writerId = c.Writers.Where(x => x.WriterName == username).Select(y => y.WriterId).FirstOrDefault();
            var values = wm.GetById(writerId);
            return View(values);
        }
        [HttpPost]
        public IActionResult WriterEditProfile(Writer w, AddProfileImage p)
        {
            w.WriterStatus = true;
            WriterValidation wv = new WriterValidation();
            ValidationResult results = wv.Validate(w);
            if (results.IsValid)
            {
                if (p.WriterImage != null)
                {
                    var extension = Path.GetExtension(p.WriterImage.FileName);
                    var newimagename = Guid.NewGuid() + extension;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newimagename);
                    var stream = new FileStream(location, FileMode.Create);
                    p.WriterImage.CopyTo(stream);
                    w.WriterImage = newimagename;
                }

                wm.Update(w);
                return RedirectToAction("Index", "DashBoard");
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
        [HttpGet]
        public IActionResult WriterAdd()
        {
           
            return View();
        }
        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage p)
        {
            Writer w = new Writer();
            if (p.WriterImage!=null)
            {
                var extension = Path.GetExtension(p.WriterImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/",newimagename);
                var stream = new FileStream(location, FileMode.Create);
                p.WriterImage.CopyTo(stream);
                w.WriterImage = newimagename;
            }
            w.WriterAbout = p.WriterAbout;
            w.WriterName = p.WriterName;
            w.WriterStatus = true;
            w.WriterPassword = p.WriterPassword;
            w.WriterMail = p.WriterMail;
            
            wm.Add(w);
            return RedirectToAction("Index","DashBoard");
        }


    }
}
