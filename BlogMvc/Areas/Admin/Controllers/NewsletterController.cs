using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace BlogMvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class NewsletterController : Controller
    {
        NewsLetterManager wm = new NewsLetterManager(new EfNewsLetterRepository());
        public IActionResult Index(int page = 1)
        {
            var values = wm.GetListAll().ToPagedList(page, 5);
            return View(values);
        }
    }
}
