using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogMvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AboutController : Controller
    {
        AboutManager am = new AboutManager(new EfAboutRepository());
        public IActionResult Index()
        {
            var value = am.GetListAll();
            return View(value);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var value = am.GetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult Edit(About a)
        {
            var value = am.GetById(a.AboutId);
            value.AboutStatus = true;   
            am.Update(a);
            return View();
        }
    }
}
