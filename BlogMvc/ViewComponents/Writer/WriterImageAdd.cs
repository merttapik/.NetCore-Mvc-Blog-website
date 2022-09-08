using BlogMvc.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlogMvc.ViewComponents.Writer
{
    public class WriterImageAdd: ViewComponent
    {
        [HttpPost]
        public IViewComponentResult Invoke()
        {
            AddProfileImage p = new AddProfileImage();
            if (p.WriterImage != null)
            {
                var extension = Path.GetExtension(p.WriterImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                p.WriterImage.CopyTo(stream);
                
            }

            return View();
        }
    }
}
