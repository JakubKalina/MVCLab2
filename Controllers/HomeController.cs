using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CarManager.Models;

namespace CarManager.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Lista samochodów do wyświetlenia
        /// </summary>
        List<CarViewModel> allCars;

        private readonly ILogger<HomeController> _logger;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

            this.allCars = new List<CarViewModel>();

            allCars.Add(new CarViewModel("Focus", "Ford", 72000, "~/Images/focus.png"));
            allCars.Add(new CarViewModel("Golf", "Volkswagen", 80000, "~/Images/golf.png"));
            allCars.Add(new CarViewModel("Civic", "Honda", 82000, "~/Images/civic.png"));
            allCars.Add(new CarViewModel("Megane", "Renault", 67000, "~/Images/megane.png"));


        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult InterestingLinks()
        {
            return View();
        }

        
        public IActionResult GetAllCars()
        {
            return View(this.allCars);
        }


        public IActionResult GetListOfModels()
        {
            List<string> allModels = new List<string>();

            foreach(CarViewModel Car in this.allCars)
            {
                allModels.Add(Car.Model);
            }

            return View(allModels);
        }

        public IActionResult GetCarByModel(string model)
        {
            CarViewModel car = this.allCars.Where(a => a.Model.ToLower() == model.ToLower()).FirstOrDefault();
            return View(car);
        }


        [HttpGet]
        public IActionResult ContactForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ContactForm(ContactFormViewModel userData)
        {
            string welcome = "Witaj: " + userData.FirstName + " " + userData.LastName;
            ViewBag.Text = welcome;

            ViewBag.Kotek = "Maurycy";

            return View("Test");
        }


        [HttpGet]
        public IActionResult UpdateCar()
        {
            var car = allCars.ElementAt(0);
            return View(car);
        }

        [HttpPost]
        public IActionResult UpdateCar(CarViewModel car)
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
