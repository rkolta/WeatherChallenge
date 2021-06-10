using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp.Controllers
{
    public class WeatherController : Controller
    {
        private readonly WeatherService _service;
        public WeatherController(WeatherService service)
        {
            _service = service;
        }
        public async Task<IActionResult> IndexAsync()
        {
            Weather model = await _service.GetWeatherAsync();
            return View(model);
        }

        public ActionResult PercentageOfFailure()
        {
            decimal percentOfFailure = _service.PercentageOfFailure();
           // Weather model = await _service.GetWeatherAsync();
            return View(percentOfFailure);
        }
    }
}
