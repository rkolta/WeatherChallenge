using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.Models
{
    public class ExceptionLog
    {
        [Key]
        public Guid Id { get; set; }
        public string StackTrace { get; set; }
        public bool WasSuccess { get; set; }
        public DateTime RequestDateTime { get; set; }
    }
}
