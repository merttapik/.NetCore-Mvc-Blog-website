using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using X.PagedList;
namespace BlogMvc.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OtherWebsiteController : Controller
    {
        public async Task<IActionResult> Index(int page = 1)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("http://localhost:6806/api/Default");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<Temp>>(jsonString).ToPagedList(page, 8);
            return View(values);
        }
    }
    public class Temp{
        public int Id { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
    }
}
