using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public class WeatherService
    {
        private readonly HttpClient _client;
        private readonly Uri _url;
        public WeatherService(HttpClient client, IConfiguration config)
        {
            _client = client;
            _url = new Uri(config.GetValue<string>("WeatherUrl"));
        }

        public async Task<Weather> GetWeatherAsync()
        {
            var response =  await _client.GetAsync(_url);
            return JsonConvert.DeserializeObject<Weather>(await response.Content.ReadAsStringAsync());

        }
    }
}
