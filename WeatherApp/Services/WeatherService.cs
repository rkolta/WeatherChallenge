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
        private readonly Context _context;

        private readonly HttpClient _client;
        private readonly Uri _url;
        public WeatherService(HttpClient client, IConfiguration config, Context context)
        {
            _context = context;
            _client = client;
            _url = new Uri(config.GetValue<string>("WeatherUrl"));
        }

        public decimal PercentageOfFailure()
        {
            List<APIInteraction> allInteractions = _context.APIInteractions.ToList();

            decimal failure = allInteractions.Where(i => i.IsSuccess == false).Count();
            decimal total = allInteractions.Count();

            decimal percentageOfFailure = (failure / total) * 100;
            return percentageOfFailure;
        }

        public async Task<Weather> GetWeatherAsync()
        {
            var response =  await _client.GetAsync(_url);

            APIInteraction apiInteraction = new APIInteraction();

            apiInteraction.APIRun = DateTime.UtcNow;
            
            if (response.IsSuccessStatusCode)
            {
                apiInteraction.IsSuccess = true;
            }
            else
            {
                apiInteraction.IsSuccess = false;
            }

            apiInteraction.StatusReturn = response.StatusCode.ToString();

            _context.Add(apiInteraction);
            _context.SaveChanges();

            return JsonConvert.DeserializeObject<Weather>(await response.Content.ReadAsStringAsync());

        }
    }
}
