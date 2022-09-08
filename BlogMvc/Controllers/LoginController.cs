using BlogMvc.Models;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlogMvc.Controllers
{
   
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
   

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult>  Index(UserSignInViewModel w)
        {
            if (ModelState.IsValid)
            {
 
                var result = await _signInManager.PasswordSignInAsync(w.UserName, w.Password, false, true);
 
                if (result.Succeeded)
                {
                   
                        return RedirectToAction("Index", "Blog");
                   
                }
                
            }
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }

        //[HttpPost]
        //public async Task<IActionResult>  Index(Writer w)
        //{
        //    Context c = new Context();
        //    var datavalue = c.Writers.FirstOrDefault(x => x.WriterMail == w.WriterMail && x.WriterPassword == w.WriterPassword);
        //    if (datavalue != null)
        //    {
        //        var claims = new List<Claim>
        //        {
        //            new Claim(ClaimTypes.Name,w.WriterMail)
        //        };
        //        var useridentity = new ClaimsIdentity(claims, "a");
        //        ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
        //        await HttpContext.SignInAsync(principal);
        //        return RedirectToAction("Index", "DashBoard");
        //    }
        //    else { return View(); }

        //}
    }
}
