using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogMvc.ViewComponents.Writer
{
    public class WriterMessageNotification: ViewComponent
    {
        MessageManager mm = new MessageManager(new EfMessageRepository());
        public IViewComponentResult Invoke()
        {
            Context c = new Context();
            var username = User.Identity.Name;
            var writerId = c.Writers.Where(x => x.WriterName == username).Select(y => y.WriterId).FirstOrDefault();

            var values = mm.GetInboxListByWriter(writerId);
            ViewBag.v1 = values.Count();
            return View(values);
        
          
           
            
        }
    }
}
