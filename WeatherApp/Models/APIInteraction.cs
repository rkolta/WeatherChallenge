using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.Models
{
    public class APIInteraction
    {
        public int Id { get; set; }
        public bool IsSuccess { get; set; }
        public DateTime APIRun { get; set; }
        public string StatusReturn { get; set; }
    }
}
