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
    public class ContactsController : Controller
    {
        ContactManager cm = new ContactManager(new EfContactRepository());
        public IActionResult Index(int page=1)
        {
            var values = cm.GetListAll().ToPagedList(page, 5);
            ViewBag.v1 = values.Count();
            return View(values);
        }
    }
}
