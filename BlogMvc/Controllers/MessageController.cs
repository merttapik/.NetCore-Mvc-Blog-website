using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogMvc.Controllers
{
    [Authorize(Roles = "User")]
    public class MessageController : Controller
    {
        
        MessageManager mm = new MessageManager(new EfMessageRepository());
        Context c = new Context();
        public IActionResult Inbox()
        {
            var username = User.Identity.Name;
            var writerId = c.Writers.Where(x => x.WriterName == username).Select(y => y.WriterId).FirstOrDefault();
           
            var values = mm.GetInboxListByWriter(writerId);
            return View(values);
        }
        [HttpGet]
        public IActionResult MessageDetails(int id)
        {
            var blogvalue = mm.GetById(id);
            return View(blogvalue);
        }
    }
}
