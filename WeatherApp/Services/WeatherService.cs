using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApp.Data;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public class WeatherService
    {
        private readonly HttpClient _client;
        private readonly Uri _url;
        private readonly DataContext _dataContext;
        public WeatherService(HttpClient client, IConfiguration config, DataContext dataContext)
        {
            _client = client;
            _url = new Uri(config.GetValue<string>("WeatherUrl"));
            _dataContext = dataContext;
        }

        public async Task SaveExperience(Weather weather)
        {
            var accessLog = new ExceptionLog
            {
                RequestDateTime = DateTime.Now,
                WasSuccess = weather != null,
            };

            _dataContext.ExceptionLogs.Add(accessLog);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<Weather> GetWeatherAsync()
        {
            var response = await _client.GetAsync(_url);
            return JsonConvert.DeserializeObject<Weather>(await response.Content.ReadAsStringAsync());

        }
    }
}
