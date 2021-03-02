using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.ViewModels
{
    public class StatisticsViewModel
    {
        public int Successes { get; set; }
        public int Failures { get; set; }

        public float Percent
        {
            get
            {
                return Math.Abs( ( (float)Failures / (Successes + Failures)) * 100) ;
            }
        }
    }
}
