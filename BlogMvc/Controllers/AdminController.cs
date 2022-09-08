using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogMvc.Controllers
{
    public class AdminController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            return View();
        }
        public PartialViewResult AdminNavbarPartial()
        {
            var usermail = User.Identity.Name;
            var writerId = c.Writers.Where(x => x.WriterName == usermail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.v1 = writerId;
            return PartialView();
        }
    }
}
