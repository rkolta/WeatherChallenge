using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Data;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp.Controllers
{
    public class WeatherController : Controller
    {
        private readonly WeatherService _service;
        private readonly DataContext _dataContext;
        public WeatherController(WeatherService service, DataContext dataContext)
        {
            _service = service;
            _dataContext = dataContext;
        }
        public async Task<IActionResult> IndexAsync()
        {
            Weather model = await _service.GetWeatherAsync();
            await _service.SaveExperience(model);

            return View(model);
        }
    }
}
