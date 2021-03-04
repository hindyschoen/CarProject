using CarProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CarProject.Controllers
{
    public class HomeController : Controller
    {
        private string _connectionString =
   @"Data Source=.\sqlexpress;Initial Catalog=Cars;Integrated Security=true;";

        public IActionResult Index(bool sort)
        {
            CarManager manager = new(_connectionString);
            CarViewModel vm = new CarViewModel
            {
                Cars = manager.GetCarsSorted(sort),
                Sort=!sort
            };

            return View(vm);
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Car car)
        {
            CarManager manager = new(_connectionString);
            manager.AddCar(car);

            return Redirect("/home/index");
        }



    }
}
