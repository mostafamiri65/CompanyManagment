using ForouzanTask.Application.Services.Interfaces;
using ForouzanTask.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ForouzanTask.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IHomeService _homeService;
        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _homeService.GetArticleList();
            ViewData["Articles"] = list;
           
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}