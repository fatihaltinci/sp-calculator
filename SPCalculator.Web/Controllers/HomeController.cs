using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SPCalculator.Service.Services.Abstractions;
using SPCalculator.Web.Models;
using System.Diagnostics;

namespace SPCalculator.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISprintService sprintService;
        private readonly IHomeService homeService;

        public HomeController(ILogger<HomeController> logger, ISprintService sprintService, IHomeService homeService)
        {
            _logger = logger;
            this.sprintService = sprintService;
            this.homeService = homeService;
        }

        public async Task<IActionResult> Index()
        {
            var sprints = await sprintService.GetAllSprintsAsync();
            var result = await homeService.GetYearlySprintCounts();
            return View(sprints);
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
        [HttpGet]
        public async Task<JsonResult> GetYearlySprintCounts()
        {
            var count = await homeService.GetYearlySprintCounts();
            return Json(JsonConvert.SerializeObject(count));
        }
        [HttpGet]
        public async Task<JsonResult> GetTotalSprintCount()
        {
            var count = await homeService.GetTotalSprintCount();
            return Json(count);
        }
        [HttpGet]
        public async Task<JsonResult> GetTotalFunctionCount()
        {
            var count = await homeService.GetTotalFunctionCount();
            return Json(count);
        }
        [HttpGet]
        public async Task<JsonResult> GetTotalParameterCount()
        {
            var count = await homeService.GetTotalParameterCount();
            return Json(count);
        }
    }
}