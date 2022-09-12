using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogMvc.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic4 : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            var usermail = User.Identity.Name;
            
            
            ViewBag.v1 = c.Writers.Where(x => x.WriterName == usermail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.v2 = c.Writers.Where(x => x.WriterName == usermail).Select(y => y.WriterImage).FirstOrDefault();
            ViewBag.v3 = c.Writers.Where(x => x.WriterName == usermail).Select(y => y.WriterAbout).FirstOrDefault();
            ViewBag.v4 = c.Writers.Count();
            ViewBag.v5 = c.Notifications.Count();
            ViewBag.v6 = c.NewsLetters.Count();
            return View();
        }
    }
}
