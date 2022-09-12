using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogMvc.ViewComponents.Admin
{
    public class Message: ViewComponent
    {
        ContactManager bm = new ContactManager(new EfContactRepository());
        public IViewComponentResult Invoke()
        {
            var value = bm.GetListAll();
            ViewBag.count = value.Count();
            return View(value);
        }
    }
}
