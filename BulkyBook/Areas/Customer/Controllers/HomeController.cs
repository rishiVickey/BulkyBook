using BulkuBook.DataAccess.IRepository;
using BulkyBook.Model.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections;
using System.Diagnostics;


namespace BulkyBook.Areas.Customer.Controllers
{
    [Area("Customer")]    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public readonly IUnitOfWork _UnitOfwork; 

        public HomeController(ILogger<HomeController> logger,IUnitOfWork unitOfwork)
        {
            _logger = logger;
            _UnitOfwork = unitOfwork;
        }

        public IActionResult Index()
        {
            var ProductList = _UnitOfwork.product.GetAll(includeProperty: "Catagory,CoverType");

            return View(ProductList);
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
