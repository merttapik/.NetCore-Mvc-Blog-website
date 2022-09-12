using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
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

    public class NotificationsController : Controller
    {
        NotificationManager nm = new NotificationManager(new EfNotificationRepository());
        public IActionResult Index(int page = 1)
        {
            var values = nm.GetListAll().ToPagedList(page, 3);
            return View(values);
        }
        [HttpGet]
        public IActionResult AddNotification()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNotification(Notification b)
        {

            NotificationValidation bv = new NotificationValidation();
            ValidationResult results = bv.Validate(b);

            if (results.IsValid)
            {

                b.NotificationStatus = true;
                b.NotificationDate= DateTime.Parse(DateTime.Now.ToShortDateString());


                nm.Add(b);
                return RedirectToAction("Index", "Notifications");
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
    }
}
