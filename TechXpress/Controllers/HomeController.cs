using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TechXpress.Interface;
using TechXpress.Models;
using TechXpress.ViewModel;

namespace TechXpress.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductRepo _productRepo;

        public HomeController(ILogger<HomeController> logger, IProductRepo productRepo)
        {
            _logger = logger;
            _productRepo = productRepo;
        }

        public IActionResult Index()
        {
            BestSellsAndLatesProductsVM viewModel = new BestSellsAndLatesProductsVM
            {
                TopRatedProducts = _productRepo.GetTopRatedProductsAsync(5).Result,
                LatestProducts = _productRepo.GetLatestProductsAsync(5).Result
            };

            return View(viewModel);
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
